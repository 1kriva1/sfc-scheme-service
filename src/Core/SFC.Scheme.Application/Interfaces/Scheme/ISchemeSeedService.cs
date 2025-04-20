namespace SFC.Scheme.Application.Interfaces.Scheme;
public interface ISchemeSeedService
{
    Task<IEnumerable<SchemeEntity>> GetSeedSchemesAsync();

    Task SeedSchemesAsync(CancellationToken cancellationToken = default);
}