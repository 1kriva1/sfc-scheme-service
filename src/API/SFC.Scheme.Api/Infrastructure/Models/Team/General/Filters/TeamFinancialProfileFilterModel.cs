using SFC.Scheme.Application.Common.Dto.Team.General.Filters;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Team.General.Filters;

/// <summary>
/// Team **financial profile filter** model.
/// </summary>
public class TeamFinancialProfileFilterModel : IMapTo<TeamFinancialProfileFilterDto>
{
    /// <summary>
    /// Describe if team can **pay** for football matches and other stuff.
    /// </summary>
    public bool? FreePlay { get; set; }
}