using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface ISchemeRepository : IRepository<SchemeEntity, ISchemeDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<SchemeEntity[]> AddRangeIfNotExistsAsync(params SchemeEntity[] entities);
}