using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Delete;
public class DeleteGameTeamPlayerHandler(IGameTeamPlayerRepository gameTeamPlayerRepository)
    : IRequestHandler<DeleteGameTeamPlayerCommand>
{
    private readonly IGameTeamPlayerRepository _gameTeamPlayerRepository = gameTeamPlayerRepository;

    public async Task Handle(DeleteGameTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        GameTeamPlayer gameTeamPlayer = await _gameTeamPlayerRepository
            .GetByIdAsync(request.GameTeamPlayer.Id).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.GameTeamPlayerNotFound);

        await _gameTeamPlayerRepository.DeleteAsync(gameTeamPlayer)
                                   .ConfigureAwait(false);
    }
}