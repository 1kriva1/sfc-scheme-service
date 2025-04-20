namespace SFC.Scheme.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface ISchemeDbContext : IDbContext
{
    #region General

    IQueryable<SchemeEntity> Schemes { get; }

    #endregion
}