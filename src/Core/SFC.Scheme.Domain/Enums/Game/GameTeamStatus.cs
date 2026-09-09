using System.ComponentModel;

namespace SFC.Scheme.Domain.Enums.Game;

public enum GameTeamStatus
{
    [Description("In Game")]
    InGame = 0,
    [Description("Out Of Game")]
    OutOfGame = 1
}