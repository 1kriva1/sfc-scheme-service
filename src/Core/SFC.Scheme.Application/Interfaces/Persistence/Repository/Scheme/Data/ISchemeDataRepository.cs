using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
public interface ISchemeDataRepository<T, TEnum> : IDataRepository<T, ISchemeDbContext, TEnum>
    where T : EnumDataEntity<TEnum>
    where TEnum : struct
{ }