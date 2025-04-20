﻿namespace SFC.Scheme.Application.Interfaces.Persistence.Context;

/// <summary>
/// Parent for all DB contexts.
/// </summary>
public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}