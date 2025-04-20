using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Player;

namespace SFC.Scheme.Application.Common.Dto.Player.General;

public record PlayerStatPointsDto : IMapFromReverse<PlayerStatPoints>
{
    public int Available { get; set; }

    public int Used { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerStatPointsDto, PlayerStatPoints>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}