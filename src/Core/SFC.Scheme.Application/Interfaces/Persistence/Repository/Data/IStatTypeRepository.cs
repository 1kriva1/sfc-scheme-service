using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
public interface IStatTypeRepository : IDataRepository<StatType, StatTypeEnum>
{
    Task<int> CountAsync();
}