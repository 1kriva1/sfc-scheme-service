using AutoMapper;

using MassTransit;

using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Messages.Events.Scheme;

namespace SFC.Scheme.Infrastructure.Services.Scheme;
public class SchemeService(IMapper mapper, IPublishEndpoint publisher) : ISchemeService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifySchemeCreatedAsync(SchemeEntity scheme, CancellationToken cancellationToken = default)
    {
        SchemeCreated @event = _mapper.Map<SchemeCreated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifySchemeUpdatedAsync(SchemeEntity scheme, CancellationToken cancellationToken = default)
    {
        SchemeUpdated @event = _mapper.Map<SchemeUpdated>(scheme);
        return _publisher.Publish(@event, cancellationToken);
    }
}