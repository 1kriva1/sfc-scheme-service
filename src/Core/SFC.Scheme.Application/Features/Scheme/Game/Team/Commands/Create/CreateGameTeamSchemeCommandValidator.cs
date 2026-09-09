using FluentValidation;

using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Validators;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;
public class CreateGameTeamSchemeCommandValidator : AbstractValidator<CreateGameTeamSchemeCommand>
{
    public CreateGameTeamSchemeCommandValidator(
        ISchemeTypeRepository schemeTypeRepository,
        IFormationRepository formationRepository,
        IFormationPositionRepository formationPositionRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        RuleFor(command => command.Scheme)
            .SetValidator(new GameTeamSchemeValidator<CreateGameTeamSchemeDto>(schemeTypeRepository, formationRepository, formationPositionRepository, teamPlayerRepository));
    }
}