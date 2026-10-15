using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;
using SFC.Scheme.Domain.Events.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Creates;

public class CreatesGameTeamPlayerCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IGameTeamPlayerRepository gameTeamPlayerRepository) : IRequestHandler<CreatesGameTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IGameTeamPlayerRepository _gameTeamPlayerRepository = gameTeamPlayerRepository;

    public async Task Handle(CreatesGameTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<GameTeamPlayer> gameTeamPlayers = _mapper.Map<IEnumerable<GameTeamPlayer>>(request.GameTeamPlayers);

        await _gameTeamPlayerRepository.AddRangeIfNotExistsAsync([.. gameTeamPlayers])
                                       .ConfigureAwait(false);

        GameTeamPlayersCreatedEvent @event = new(gameTeamPlayers);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}