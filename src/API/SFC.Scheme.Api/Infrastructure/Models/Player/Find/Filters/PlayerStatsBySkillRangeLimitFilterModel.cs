﻿using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Dto.Player.Filters;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Range limit by **stat skill**.
/// </summary>
public class PlayerStatsBySkillRangeLimitFilterModel :
    RangeLimitModel<short?>,
    IMapTo<PlayerStatsBySkillRangeLimitFilterDto>
{
    /// <summary>
    /// Stat skill unique identifier.
    /// </summary>
    public int Skill { get; set; }
}