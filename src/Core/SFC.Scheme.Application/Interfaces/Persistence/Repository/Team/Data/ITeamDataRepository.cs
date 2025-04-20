using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;

/// <summary>
/// Data related repository (Data service).
/// Enum based entities.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TEnum">Enum type.</typeparam>
public interface ITeamDataRepository<TEntity, TEnum> : IDataRepository<TEntity, ITeamDbContext, TEnum>
    where TEntity : EnumDataEntity<TEnum>
    where TEnum : struct
{ }