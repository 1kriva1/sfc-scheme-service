using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Domain.Entities.Game.General;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Game : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public GameStatusEnum StatusId { get; set; }

    public required GameGeneralProfile GeneralProfile { get; set; }

    public required GameFinancialProfile FinancialProfile { get; set; }

    public required GameInventaryProfile InventaryProfile { get; set; }

    public required GameAvailability Availability { get; set; }

    public ICollection<GameTag> Tags { get; } = [];

    public ICollection<GameTeamScheme> TeamSchemes { get; } = [];
}