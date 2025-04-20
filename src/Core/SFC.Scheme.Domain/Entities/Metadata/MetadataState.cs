using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Metadata;
public class MetadataState : EnumEntity<MetadataStateEnum>
{
    public MetadataState() : base() { }

    public MetadataState(MetadataStateEnum enumType) : base(enumType) { }
}