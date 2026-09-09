using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
public class GameTeamSchemeDto : AuditableDto, IMapFromReverse<GameTeamScheme>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public required TeamDto Team { get; set; } = default!;

    public required GameDto Game { get; set; } = default!;

    public required GameTeamSchemeProfileDto Profile { get; set; }

    public required GameTeamSchemeFormationDto Formation { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameTeamSchemeDto, GameTeamScheme>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.CreatedDate, d => d.Ignore())
                .ForMember(p => p.CreatedBy, d => d.Ignore())
                .ForMember(p => p.LastModifiedDate, d => d.Ignore())
                .ForMember(p => p.LastModifiedBy, d => d.Ignore());

        profile.CreateMap<GameTeamScheme, GameTeamSchemeDto>()
                .ForMember(p => p.Profile, d => d.MapFrom(z => z));
    }
}