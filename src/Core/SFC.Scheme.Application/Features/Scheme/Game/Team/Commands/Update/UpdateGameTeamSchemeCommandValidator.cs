using FluentValidation;

using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Validators;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;
public class UpdateGameTeamSchemeCommandValidator : AbstractValidator<UpdateGameTeamSchemeCommand>
{
    public UpdateGameTeamSchemeCommandValidator(
        ISchemeTypeRepository schemeTypeRepository,
        IFormationRepository formationRepository,
        IFormationPositionRepository formationPositionRepository,
        IGameTeamPlayerRepository gameTeamPlayerRepository)
    {
        RuleFor(command => command.Scheme)
            .SetValidator(new GameTeamSchemeValidator<UpdateGameTeamSchemeDto>(schemeTypeRepository, formationRepository, formationPositionRepository, gameTeamPlayerRepository));
    }
}