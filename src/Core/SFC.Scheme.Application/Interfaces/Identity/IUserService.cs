﻿namespace SFC.Scheme.Application.Interfaces.Identity;

/// <summary>
/// User service (JWT + OpenID based).
/// </summary>
public interface IUserService
{
    Guid? GetUserId();
}