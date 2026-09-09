namespace SFC.Scheme.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // data
    InitData,
    ResetData,
    // identity
    CreateUser,
    CreateUsers,
    // player
    CreatePlayer,
    UpdatePlayer,
    CreatePlayers,
    // team
    ResetTeamData,
    CreateTeam,
    UpdateTeam,
    CreateTeams,
    // team player
    CreateTeamPlayer,
    UpdateTeamPlayer,
    CreateTeamPlayers,
    // game
    ResetGameData,
    CreateGame,
    UpdateGame,
    CreateGames,
    // game player
    CreateGamePlayer,
    UpdateGamePlayer,
    CreateGamePlayers,
    // game team
    CreateGameTeam,
    UpdateGameTeam,
    CreateGameTeams,
    // scheme
    GetAllSchemeData,
    // team scheme
    CreateTeamScheme,
    UpdateTeamScheme,
    DeleteTeamScheme,
    GetTeamScheme,
    GetTeamSchemes,
    // game team scheme
    CreateGameTeamScheme,
    UpdateGameTeamScheme,
    DeleteGameTeamScheme,
    GetGameTeamScheme,
    GetGameTeamSchemes
}