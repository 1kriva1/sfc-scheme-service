using SFC.Scheme.Application.Interfaces.Scheme.Data.Models;

namespace SFC.Scheme.Application.Interfaces.Scheme.Data;
public interface ISchemeDataService
{
    Task<GetAllSchemeDataModel> GetAllSchemeDataAsync();

    Task PublishDataInitializedEventAsync(CancellationToken cancellationToken);
}