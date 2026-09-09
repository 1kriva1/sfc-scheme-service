using AutoMapper;

using MassTransit;

using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Messages.Events.Scheme.Game.Team;

namespace SFC.Scheme.Infrastructure.Services.Scheme.Game.Team;
public class GameTeamSchemeService(IMapper mapper, IPublishEndpoint publisher) : IGameTeamSchemeService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGameTeamSchemeCreatedAsync(GameTeamScheme scheme, CancellationToken cancellationToken = default)
    {
        GameTeamSchemeCreated @event = _mapper.Map<GameTeamSchemeCreated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGameTeamSchemeUpdatedAsync(GameTeamScheme scheme, CancellationToken cancellationToken = default)
    {
        GameTeamSchemeUpdated @event = _mapper.Map<GameTeamSchemeUpdated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }
}