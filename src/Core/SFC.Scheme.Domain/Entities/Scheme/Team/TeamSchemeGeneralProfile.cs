using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamSchemeGeneralProfile : BaseEntity<long>
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public SchemeTypeEnum TypeId { get; set; }

    public FormationEnum FormationId { get; set; }

    public TeamScheme Scheme { get; set; } = default!;
}