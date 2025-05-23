using FluentValidation;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Validators;
public class TeamSchemeValidator<T> : AbstractValidator<T> where T : TeamSchemeDto
{
    private readonly ISchemeTypeRepository _schemeTypeRepository;
    private readonly IFormationRepository _formationRepository;
    private readonly IFormationPositionRepository _formationPositionRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public TeamSchemeValidator(
        ISchemeTypeRepository schemeTypeRepository,
        IFormationRepository formationRepository,
        IFormationPositionRepository formationPositionRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        _schemeTypeRepository = schemeTypeRepository;
        _formationRepository = formationRepository;
        _formationPositionRepository = formationPositionRepository;
        _teamPlayerRepository = teamPlayerRepository;

        SetRulesForGeneralProfile();

        SetRulesForPlayers();
    }

    private void SetRulesForGeneralProfile()
    {
        RuleFor(p => p.Profile.General.Name)
           .RequiredProperty(ValidationConstants.NameValueMaxLength, nameof(TeamSchemeGeneralProfileDto.Name));

        RuleFor(p => p.Profile.General.Comment)
           .MaximumLength(ValidationConstants.DescriptionValueMaxLength)
           .WithName(nameof(TeamSchemeGeneralProfileDto.Comment));

        RuleFor(p => p.Profile.General.TypeId)
            .MustAsync((value, cancellation) => _schemeTypeRepository.AnyAsync((SchemeTypeEnum)value))
            .WithName(nameof(TeamSchemeGeneralProfileDto.TypeId))
            .WithMessage(Localization.DataValidator);

        RuleFor(p => p.Profile.General.FormationId)
            .MustAsync((value, cancellation) => _formationRepository.AnyAsync((FormationEnum)value))
            .WithName(nameof(TeamSchemeGeneralProfileDto.FormationId))
            .WithMessage(Localization.DataValidator);
    }

    private void SetRulesForPlayers()
    {
        RuleFor(p => p.Players)
            .MustAsync(async (value, players, cancellation) =>
            {
                IEnumerable<long> playerIds = players.Select(p => p.PlayerId);
                return await _teamPlayerRepository.CountAsync(value.TeamId, playerIds).ConfigureAwait(true) == playerIds.Count();
            })
            .WithName(nameof(TeamSchemeDto.Players))
            .WithMessage(Localization.EachPlayerMustBeInTeam);

        RuleForEach(p => p.Players)
            .Must(player => player.Position is not null)
            .WithName(nameof(TeamSchemePlayerDto.Position))
            .WithMessage(Localization.EachValueMustNotBeEmpty);

        RuleForEach(p => p.Players)
            .Must((value, player) => !value.Players
                    .GroupBy(p => p.PlayerId)
                    .Where(g => g.Count() > 1)
                    .Select(id => id.Key)
                    .Contains(player.PlayerId))
            .WithName(nameof(TeamSchemePlayerDto.PlayerId))
            .WithMessage(Localization.EachValueMustBeUnique);

        RuleForEach(p => p.Players)
            .Where(p => p.Position is not null)
            // each value of FormationPositionId must be valid
            .MustAsync(async (player, cancellation) => await _formationPositionRepository.AnyAsync(player.Position!.FormationPositionId).ConfigureAwait(true))
            .WithName(nameof(TeamSchemePlayerPositionDto.FormationPositionId))
            .WithMessage(Localization.EachValueMustBeInDataRange)
            // each combination Index AND FormationPositionId must be unique
            .Must((value, player) => value.Players.Count(p =>
                p.Position is not null &&
                p.Position.Index == player.Position.Index &&
                p.Position.FormationPositionId == player.Position.FormationPositionId) == 1)
            .WithName($"{nameof(TeamSchemePlayerPositionDto.Index)} And {nameof(TeamSchemePlayerPositionDto.FormationPositionId)}")
            .WithMessage(Localization.EachValueMustBeUnique)
            // each combination Index AND FormationPositionId should belong to formation
            .MustAsync(async (value, player, cancellation) =>
            {
                Formation? formation = await _formationRepository.GetByIdAsync((FormationEnum)value.Profile.General.FormationId).ConfigureAwait(true);
                return formation is null || formation.Values.Any(v => v.Index == player.Position.Index && v.FormationPositionId == player.Position.FormationPositionId);
            })
            .WithName($"{nameof(TeamSchemePlayerPositionDto.Index)} And {nameof(TeamSchemePlayerPositionDto.FormationPositionId)}")
            .WithMessage(Localization.DataValidator);
    }
}