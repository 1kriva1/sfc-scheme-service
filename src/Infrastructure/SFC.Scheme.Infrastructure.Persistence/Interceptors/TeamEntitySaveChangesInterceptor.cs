using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Reference;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Infrastructure.Persistence.Extensions;

namespace SFC.Scheme.Infrastructure.Persistence.Interceptors;
public class TeamEntitySaveChangesInterceptor(ITeamReference teamReference) : SaveChangesInterceptor
{
    private readonly ITeamReference _teamReference = teamReference;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context, cancellationToken);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context, CancellationToken cancellationToken = default)
    {
        if (context == null) return;

        IEnumerable<EntityEntry<ITeamEntity>> entries = context.ChangeTracker.Entries<ITeamEntity>();

        foreach (EntityEntry<ITeamEntity> entry in entries)
        {
            if (entry.Entity.Team is null)
            {
                Task<TeamEntity> team = GetTeamAsync(entry.Entity.TeamId, cancellationToken);
                entry.SetReference(context, team.Result);
            }
        }
    }

    private async Task<TeamEntity> GetTeamAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _teamReference.GetAsync(id, cancellationToken).ConfigureAwait(true)
                    ?? throw new NotFoundException(Localization.TeamNotFound);
    }
}