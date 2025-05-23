using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Data;
public class FormationPosition : EnumDataEntity<FormationPositionEnum>
{
    public FormationPosition() : base() { }

    public FormationPosition(FormationPositionEnum enumType) : base(enumType) { }

    public FootballPositionEnum FootballPositionId { get; set; }
}