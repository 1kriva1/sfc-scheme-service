using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Metadata;
public class MetadataDomain : EnumEntity<MetadataDomainEnum>
{
    public MetadataDomain() : base() { }

    public MetadataDomain(MetadataDomainEnum enumType) : base(enumType) { }
}