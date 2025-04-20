using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Common;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data;
public class DataRepository<T, TEnum>(DataDbContext context)
    : DataRepository<T, DataDbContext, TEnum>(context), IDataRepository<T, TEnum>
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{ }