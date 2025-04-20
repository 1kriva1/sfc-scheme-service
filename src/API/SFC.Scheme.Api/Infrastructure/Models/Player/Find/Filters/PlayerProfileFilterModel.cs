﻿using SFC.Scheme.Application.Common.Dto.Player.Filters;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Get players **profile filter** model.
/// </summary>
public class PlayerProfileFilterModel : IMapTo<PlayerProfileFilterDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public PlayerGeneralProfileFilterModel General { get; set; } = default!;

    /// <summary>
    /// Football profile.
    /// </summary>
    public PlayerFootballProfileFilterModel Football { get; set; } = default!;
}