
using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
public class FormationPositionCacheRepository(FormationPositionRepository repository, ICache cache)
    : SchemeDataCacheRepository<FormationPosition, FormationPositionEnum>(repository, cache), IFormationPositionRepository
{ }