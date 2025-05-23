using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Domain.Events.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Delete;
public class DeleteTeamSchemeCommandHandler(ITeamSchemeRepository teamSchemeRepository)
    : IRequestHandler<DeleteTeamSchemeCommand>
{
    private readonly ITeamSchemeRepository _teamSchemeRepository = teamSchemeRepository;

    public async Task Handle(DeleteTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        TeamScheme scheme = await _teamSchemeRepository.GetByIdAsync(request.Scheme.Id, request.Scheme.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        scheme.AddDomainEvent(new TeamSchemeDeletedEvent(scheme));

        await _teamSchemeRepository.DeleteAsync(scheme)
                                   .ConfigureAwait(true);
    }
}