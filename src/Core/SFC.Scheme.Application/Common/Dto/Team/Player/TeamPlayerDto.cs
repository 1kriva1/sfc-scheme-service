using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Team.Player;

namespace SFC.Scheme.Application.Common.Dto.Team.Player;
public class TeamPlayerDto : AuditableDto, IMapFromReverse<TeamPlayer>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public Guid UserId { get; set; }
}