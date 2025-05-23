using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Base;

/// <summary>
/// Core entity of the service.
/// </summary>
public abstract class Scheme : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }
}