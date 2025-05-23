using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Data;
public class FormationValue : DataEntity<int>
{
    public int Line { get; set; }

    public int Index { get; set; }

    public FormationEnum FormationId { get; set; }

    public FormationPositionEnum FormationPositionId { get; set; }
}