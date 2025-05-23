using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Common;
public class DataEntity<TId> : BaseEntity<TId>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}