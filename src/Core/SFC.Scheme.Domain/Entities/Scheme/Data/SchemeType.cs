using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Data;
public class SchemeType : EnumDataEntity<SchemeTypeEnum>
{
    public SchemeType() : base() { }

    public SchemeType(SchemeTypeEnum enumType) : base(enumType) { }
}