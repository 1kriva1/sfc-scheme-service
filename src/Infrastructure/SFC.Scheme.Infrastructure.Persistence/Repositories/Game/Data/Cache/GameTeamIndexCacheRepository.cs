using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameTeamIndexCacheRepository(GameTeamIndexRepository repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : GameDataCacheRepository<GameTeamIndex, GameTeamIndexEnum>(repository, cache), IGameTeamIndexRepository
{ }