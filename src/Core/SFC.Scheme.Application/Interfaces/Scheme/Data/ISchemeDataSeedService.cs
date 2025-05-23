namespace SFC.Scheme.Application.Interfaces.Scheme.Data;
public interface ISchemeDataSeedService
{
    Task SeedDataAsync(CancellationToken cancellationToken = default);
}