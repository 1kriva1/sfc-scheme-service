using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game model.
/// </summary>
public class GameModel : IMapFrom<GameDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game's profile model.
    /// </summary>
    public GameProfileModel Profile { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GameDto, GameModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}