using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.General;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Scheme : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }
}