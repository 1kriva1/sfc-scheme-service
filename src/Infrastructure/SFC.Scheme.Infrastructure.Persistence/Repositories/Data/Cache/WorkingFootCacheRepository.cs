using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class WorkingFootCacheRepository(WorkingFootRepository repository, ICache cache)
    : DataCacheRepository<WorkingFoot, WorkingFootEnum>(repository, cache), IWorkingFootRepository
{ }