using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Game;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface ISchemeDbContext : IDbContext
{
    #region General

    IQueryable<TeamScheme> TeamSchemes { get; }

    IQueryable<GameScheme> GameSchemes { get; }

    #endregion

    #region Data

    IQueryable<Formation> Formations { get; }

    IQueryable<FormationPosition> FormationPositions { get; }

    IQueryable<FormationValue> FormationValues { get; }

    IQueryable<SchemeType> SchemeTypes { get; }

    #endregion Data
}