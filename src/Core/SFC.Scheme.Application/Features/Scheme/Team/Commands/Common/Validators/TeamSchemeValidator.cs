using FluentValidation;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Scheme.Domain.Entities.Scheme.Data;

using TeamSchemeFormationDto = SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto.TeamSchemeFormationDto;

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

        SetRulesForFormation();
    }

    private void SetRulesForGeneralProfile()
    {
        RuleFor(p => p.Profile.General.Name)
           .RequiredProperty(ValidationConstants.NameValueMaxLength, nameof(TeamSchemeGeneralProfileDto.Name));

        RuleFor(p => p.Profile.General.Comment)
           .MaximumLength(ValidationConstants.DescriptionValueMaxLength)
           .WithName(nameof(TeamSchemeGeneralProfileDto.Comment));
    }

    private void SetRulesForFormation()
    {
        RuleFor(p => p.Formation.TypeId)
            .MustAsync((value, cancellation) => _schemeTypeRepository.AnyAsync((SchemeTypeEnum)value))
            .WithName(nameof(TeamSchemeFormationDto.TypeId))
            .WithMessage(Localization.DataValidator);

        RuleFor(p => p.Formation.FormationId)
            .MustAsync((value, cancellation) => _formationRepository.AnyAsync((FormationEnum)value))
            .WithName(nameof(TeamSchemeFormationDto.FormationId))
            .WithMessage(Localization.DataValidator);

        RuleFor(p => p.Formation.Players)
            .MustAsync(async (value, players, cancellation) =>
            {
                IEnumerable<long> playerIds = players.Select(p => p.PlayerId);
                return await _teamPlayerRepository.CountAsync(value.TeamId, playerIds).ConfigureAwait(true) == playerIds.Count();
            })
            .WithName(nameof(TeamSchemeFormationDto.Players))
            .WithMessage(Localization.EachPlayerMustBeInTeam);

        RuleForEach(p => p.Formation.Players)
            .Must(player => player.Position is not null)
            .WithName(nameof(TeamSchemeFormationPlayerDto.Position))
            .WithMessage(Localization.EachValueMustNotBeEmpty);

        RuleForEach(p => p.Formation.Players)
            .Must((value, player) => !value.Formation.Players
                    .GroupBy(p => p.PlayerId)
                    .Where(g => g.Count() > 1)
                    .Select(id => id.Key)
                    .Contains(player.PlayerId))
            .WithName(nameof(TeamSchemeFormationPlayerDto.PlayerId))
            .WithMessage(Localization.EachValueMustBeUnique);

        RuleForEach(p => p.Formation.Players)
            .Where(p => p.Position is not null)
            // each value of FormationPositionId must be valid
            .MustAsync(async (player, cancellation) => await _formationPositionRepository.AnyAsync(player.Position!.FormationPositionId).ConfigureAwait(true))
            .WithName(nameof(TeamSchemeFormationPlayerPositionDto.FormationPositionId))
            .WithMessage(Localization.EachValueMustBeInDataRange)
            // each combination Index AND FormationPositionId must be unique
            .Must((value, player) => value.Formation.Players.Count(p =>
                p.Position is not null &&
                p.Position.Index == player.Position.Index &&
                p.Position.FormationPositionId == player.Position.FormationPositionId) == 1)
            .WithName($"{nameof(TeamSchemeFormationPlayerPositionDto.Index)} And {nameof(TeamSchemeFormationPlayerPositionDto.FormationPositionId)}")
            .WithMessage(Localization.EachValueMustBeUnique)
            // each combination Index AND FormationPositionId should belong to formation
            .MustAsync(async (value, player, cancellation) =>
            {
                Formation? formation = await _formationRepository.GetByIdAsync((FormationEnum)value.Formation.FormationId).ConfigureAwait(true);
                return formation is null || formation.Values.Any(v => v.Index == player.Position.Index && v.FormationPositionId == player.Position.FormationPositionId);
            })
            .WithName($"{nameof(TeamSchemeFormationPlayerPositionDto.Index)} And {nameof(TeamSchemeFormationPlayerPositionDto.FormationPositionId)}")
            .WithMessage(Localization.DataValidator);
    }
}