using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Delete;
public class DeleteGameTeamSchemeCommandHandler(IGameTeamSchemeRepository gameTeamSchemeRepository)
    : IRequestHandler<DeleteGameTeamSchemeCommand>
{
    private readonly IGameTeamSchemeRepository _gameTeamSchemeRepository = gameTeamSchemeRepository;

    public async Task Handle(DeleteGameTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        GameTeamScheme scheme = await _gameTeamSchemeRepository.GetByIdAsync(request.Scheme.Id, request.Scheme.GameId, request.Scheme.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        scheme.AddDomainEvent(new GameTeamSchemeDeletedEvent(scheme));

        await _gameTeamSchemeRepository.DeleteAsync(scheme)
                                       .ConfigureAwait(true);
    }
}