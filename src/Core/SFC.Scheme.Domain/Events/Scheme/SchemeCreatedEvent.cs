using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Events.Scheme;
public class SchemeCreatedEvent(SchemeEntity entity) : BaseEvent
{
    public SchemeEntity Scheme { get; } = entity;
}