using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Domain.Events.Identity;
public class UsersCreatedEvent(IEnumerable<User> users) : BaseEvent
{
    public IEnumerable<User> Users { get; } = users;
}