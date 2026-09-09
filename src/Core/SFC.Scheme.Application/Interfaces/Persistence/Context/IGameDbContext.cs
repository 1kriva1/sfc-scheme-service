using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Entities.Game.General;
using SFC.Scheme.Domain.Entities.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Context;
public interface IGameDbContext : IDbContext
{
    #region General

    IQueryable<GameEntity> Games { get; }

    IQueryable<GameGeneralProfile> GeneralProfiles { get; }

    IQueryable<GameFinancialProfile> FinancialProfiles { get; }

    IQueryable<GameInventaryProfile> InventaryProfiles { get; }

    IQueryable<GameAvailability> Availabilities { get; }

    IQueryable<GameTag> Tags { get; }

    #endregion General

    #region Team

    IQueryable<GameTeam> GameTeams { get; }

    #endregion Team

    #region Data

    IQueryable<GameStatus> GameStatuses { get; }

    IQueryable<GameTeamStatus> GameTeamStatuses { get; }

    IQueryable<GameTeamIndex> GameTeamIndexes { get; }

    #endregion Data
}