using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Application.Interfaces.Persistence.Context;

/// <summary>
/// Identity service related entities.
/// </summary>
public interface IIdentityDbContext : IDbContext
{
    IQueryable<User> Users { get; }
}