using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
public class TeamSchemeDto : AuditableDto, IMapToReverse<TeamScheme>
{
    public long TeamId { get; set; }

    public required TeamSchemeProfileDto Profile { get; set; }

    public IEnumerable<TeamSchemePlayerDto> Players { get; set; } = default!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamSchemeDto, TeamScheme>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.CreatedDate, d => d.Ignore())
                .ForMember(p => p.CreatedBy, d => d.Ignore())
                .ForMember(p => p.LastModifiedDate, d => d.Ignore())
                .ForMember(p => p.LastModifiedBy, d => d.Ignore())
                .ReverseMap();
    }
}