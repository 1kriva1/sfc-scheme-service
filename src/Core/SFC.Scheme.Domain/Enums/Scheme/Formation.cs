using System.ComponentModel;

namespace SFC.Scheme.Domain.Enums.Scheme;
public enum Formation
{
    [Description("Powerfull Attacking")]
    PowerfullAttacking = 0,
    Control = 1,
    Defend = 2,
    Atacking = 3,
    Balanced = 4,
    [Description("Box To Box")]
    BoxToBox = 5,
    [Description("Fake Nine")]
    FakeNine = 6
}