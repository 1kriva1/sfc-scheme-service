using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Entities.Game.General;
using SFC.Scheme.Domain.Entities.Game.Player;
using SFC.Scheme.Domain.Entities.Game.Team.General;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

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

    #region Player

    IQueryable<GamePlayer> GamePlayers { get; }

    #endregion Player

    IQueryable<GameTeam> GameTeams { get; }

    IQueryable<GameTeamPlayer> GameTeamPlayers { get; }

    #endregion Team    

    #region Data

    IQueryable<GameStatus> GameStatuses { get; }

    IQueryable<GameTeamStatus> GameTeamStatuses { get; }

    IQueryable<GameTeamIndex> GameTeamIndexes { get; }

    IQueryable<GamePlayerStatus> GamePlayerStatuses { get; }

    #endregion Data
}