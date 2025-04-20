using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Metadata;
public class MetadataType : EnumEntity<MetadataTypeEnum>
{
    public MetadataType() : base() { }

    public MetadataType(MetadataTypeEnum enumType) : base(enumType) { }
}