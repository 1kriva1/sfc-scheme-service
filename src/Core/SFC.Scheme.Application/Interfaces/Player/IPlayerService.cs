﻿using SFC.Scheme.Application.Common.Dto.Player.General;

namespace SFC.Scheme.Application.Interfaces.Player;
public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default);
}