using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Data;
public class Shirt : EnumDataEntity<ShirtEnum>
{
    public Shirt() : base() { }

    public Shirt(ShirtEnum enumType) : base(enumType) { }
}