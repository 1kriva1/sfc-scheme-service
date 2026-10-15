using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Team.General;
using SFC.Scheme.Application.Common.Dto.Game.Team.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.Team.General;

/// <summary>
/// Game Team model.
/// </summary>
public class GameTeamModel : IMapFrom<GameTeamDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Team status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game Team index.
    /// </summary>
    public int? Index { get; set; }

    /// <summary>
    /// Game Team related to this team.
    /// </summary>
    public TeamModel? Team { get; set; }

    /// <summary>
    /// Game Team related to this team.
    /// </summary>
    public IEnumerable<GameTeamGameTeamPlayerModel>? Players { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamDto, GameTeamModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}