using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Data;

public class Formation : EnumDataEntity<FormationEnum>
{
    public Formation() : base() { }

    public Formation(FormationEnum enumType) : base(enumType) { }

    public Formation(FormationEnum enumType, ICollection<FormationValue> values) : base(enumType)
    {
        Values = values;
    }

    public ICollection<FormationValue> Values { get; init; } = [];
}