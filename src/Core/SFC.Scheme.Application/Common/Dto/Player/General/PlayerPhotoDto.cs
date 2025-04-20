using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Converters.File;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Domain.Entities.Player;

namespace SFC.Scheme.Application.Common.Dto.Player.General;
public class PlayerPhotoDto : FileDto, IMapFromReverse<PlayerPhoto>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerPhoto, PlayerPhotoDto>();

        profile.CreateMap<string?, PlayerPhotoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto, PlayerPhoto>()
               .IgnoreAllNonExisting();
    }
}