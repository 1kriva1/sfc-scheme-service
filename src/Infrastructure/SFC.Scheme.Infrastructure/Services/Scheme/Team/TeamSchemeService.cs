using AutoMapper;

using MassTransit;

using SFC.Scheme.Application.Interfaces.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Messages.Events.Scheme.Team;

namespace SFC.Scheme.Infrastructure.Services.Scheme.Team;
public class TeamSchemeService(IMapper mapper, IPublishEndpoint publisher) : ITeamSchemeService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyTeamSchemeCreatedAsync(TeamScheme scheme, CancellationToken cancellationToken = default)
    {
        TeamSchemeCreated @event = _mapper.Map<TeamSchemeCreated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyTeamSchemeUpdatedAsync(TeamScheme scheme, CancellationToken cancellationToken = default)
    {
        TeamSchemeUpdated @event = _mapper.Map<TeamSchemeUpdated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }
}