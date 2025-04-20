using System.ComponentModel;

namespace SFC.Scheme.Domain.Enums.Metadata;
public enum MetadataState
{
    [Description("Not Required")]
    NotRequired,
    Required,
    Done
}