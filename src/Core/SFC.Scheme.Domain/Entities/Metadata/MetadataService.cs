using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Metadata;
public class MetadataService : EnumEntity<MetadataServiceEnum>
{
    public MetadataService() : base() { }

    public MetadataService(MetadataServiceEnum enumType) : base(enumType) { }
}