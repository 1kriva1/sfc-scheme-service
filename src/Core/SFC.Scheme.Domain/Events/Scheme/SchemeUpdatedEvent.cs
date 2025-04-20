using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Events.Scheme;
public class SchemeUpdatedEvent(SchemeEntity entity) : BaseEvent
{
    public SchemeEntity Scheme { get; } = entity;
}