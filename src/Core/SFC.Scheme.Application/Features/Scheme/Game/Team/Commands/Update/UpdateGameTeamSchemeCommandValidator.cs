using FluentValidation;

using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Validators;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;
public class UpdateGameTeamSchemeCommandValidator : AbstractValidator<UpdateGameTeamSchemeCommand>
{
    public UpdateGameTeamSchemeCommandValidator(
        ISchemeTypeRepository schemeTypeRepository,
        IFormationRepository formationRepository,
        IFormationPositionRepository formationPositionRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        RuleFor(command => command.Scheme)
            .SetValidator(new GameTeamSchemeValidator<UpdateGameTeamSchemeDto>(schemeTypeRepository, formationRepository, formationPositionRepository, teamPlayerRepository));
    }
}