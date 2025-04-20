namespace SFC.Scheme.Application.Interfaces.Scheme;
public interface ISchemeService
{
    Task NotifySchemeCreatedAsync(SchemeEntity scheme, CancellationToken cancellationToken = default);

    Task NotifySchemeUpdatedAsync(SchemeEntity scheme, CancellationToken cancellationToken = default);
}