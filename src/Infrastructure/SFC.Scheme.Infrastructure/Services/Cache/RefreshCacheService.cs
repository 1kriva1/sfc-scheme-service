using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Scheme.Data.Models;

namespace SFC.Scheme.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, ISchemeDataService schemeDataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly ISchemeDataService _schemeDataService = schemeDataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllSchemeDataModel model = await _schemeDataService.GetAllSchemeDataAsync().ConfigureAwait(true);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        RefreshAsync(model.Formations, token);

        RefreshAsync(model.FormationPositions, token);

        RefreshAsync(model.SchemeTypes, token);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}