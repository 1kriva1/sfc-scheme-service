﻿using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player model.
/// </summary>
public class PlayerModel : IMapFrom<PlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Player's profile model.
    /// </summary>
    public PlayerProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Player's stats model.
    /// </summary>
    public PlayerStatsModel Stats { get; set; } = null!;
}