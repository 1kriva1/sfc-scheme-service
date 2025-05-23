using FluentValidation;

using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Validators;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
public class CreateTeamSchemeCommandValidator : AbstractValidator<CreateTeamSchemeCommand>
{
    public CreateTeamSchemeCommandValidator(
        ISchemeTypeRepository schemeTypeRepository,
        IFormationRepository formationRepository,
        IFormationPositionRepository formationPositionRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        RuleFor(command => command.Scheme)
            .SetValidator(new TeamSchemeValidator<CreateTeamSchemeDto>(schemeTypeRepository, formationRepository, formationPositionRepository, teamPlayerRepository));
    }
}