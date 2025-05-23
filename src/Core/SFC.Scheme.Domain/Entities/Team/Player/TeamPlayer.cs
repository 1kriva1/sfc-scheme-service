﻿using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Team.Player;
public class TeamPlayer : BaseAuditableReferenceEntity<long>, IUserEntity, IPlayerEntity, ITeamEntity
{
    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public required TeamEntity Team { get; set; }

    public long PlayerId { get; set; }

    public required PlayerEntity Player { get; set; }

    public TeamPlayerStatusEnum StatusId { get; set; }
}