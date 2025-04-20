using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Domain.Common;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamDataRepository<TEntity, TEnum>(TeamDbContext context)
    : DataRepository<TEntity, TeamDbContext, TEnum>(context), ITeamDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }