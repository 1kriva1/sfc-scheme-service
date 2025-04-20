using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Converters.File;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Domain.Entities.Team.General;

namespace SFC.Scheme.Application.Common.Dto.Team.General;
public class TeamLogoDto : FileDto, IMapFromReverse<TeamLogo>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamLogo, TeamLogoDto>();

        profile.CreateMap<string?, TeamLogoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto, TeamLogo>()
               .IgnoreAllNonExisting();
    }
}