using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Events.Game.Data;

namespace SFC.Scheme.Application.Features.Game.Data.Commands.Reset;

public class ResetGameDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IGameStatusRepository gameStatusRepository,
    IGameTeamStatusRepository gameTeamStatusRepository,
    IGameTeamIndexRepository gameTeamIndexRepository) : IRequestHandler<ResetGameDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;
    private readonly IGameStatusRepository _gameStatusRepository = gameStatusRepository;
    private readonly IGameTeamStatusRepository _gameTeamStatusRepository = gameTeamStatusRepository;
    private readonly IGameTeamIndexRepository _gameTeamIndexRepository = gameTeamIndexRepository;

    public async Task Handle(ResetGameDataCommand request, CancellationToken cancellationToken)
    {
        await _gameStatusRepository
            .ResetAsync(_mapper.Map<IEnumerable<GameStatus>>(request.GameStatuses))
            .ConfigureAwait(false);

        await _gameTeamStatusRepository
            .ResetAsync(_mapper.Map<IEnumerable<GameTeamStatus>>(request.GameTeamStatuses))
            .ConfigureAwait(false);

        await _gameTeamIndexRepository
            .ResetAsync(_mapper.Map<IEnumerable<GameTeamIndex>>(request.GameTeamIndexes))
            .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        GameDataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}