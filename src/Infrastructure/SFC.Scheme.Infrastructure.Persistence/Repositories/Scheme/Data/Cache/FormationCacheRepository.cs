using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
public class FormationCacheRepository(FormationRepository repository, ICache cache)
    : SchemeDataCacheRepository<Formation, FormationEnum>(repository, cache), IFormationRepository
{ }