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
    // core
    GetAllSchemeData,
    CreateTeamScheme,
    UpdateTeamScheme,
    DeleteTeamScheme,
    GetTeamScheme,
    GetTeamSchemes,
}