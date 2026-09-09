using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Common.Dto;
public class GameTeamSchemeDto : AuditableDto, IMapToReverse<GameTeamScheme>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public required GameTeamSchemeProfileDto Profile { get; set; }

    public required GameTeamSchemeFormationDto Formation { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameTeamSchemeDto, GameTeamScheme>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.CreatedDate, d => d.Ignore())
                .ForMember(p => p.CreatedBy, d => d.Ignore())
                .ForMember(p => p.LastModifiedDate, d => d.Ignore())
                .ForMember(p => p.LastModifiedBy, d => d.Ignore())
                .ReverseMap();
    }
}