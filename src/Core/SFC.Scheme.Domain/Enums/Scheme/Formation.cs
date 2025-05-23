using System.ComponentModel;

namespace SFC.Scheme.Domain.Enums.Scheme;
public enum Formation
{
    [Description("Powerfull attacking formation")]
    PowerfullAttacking = 0,
    [Description("Control formation")]
    Control = 1,
    [Description("Defend formation")]
    Defend = 2,
    [Description("Atacking formation")]
    Atacking = 3,
    [Description("Balanced formation")]
    Balanced = 4,
    [Description("Box to box")]
    BoxToBox = 5,
    [Description("With fake number nine")]
    FakeNine = 6
}