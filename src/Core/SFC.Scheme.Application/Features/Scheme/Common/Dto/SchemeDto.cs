using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Application.Features.Scheme.Common.Dto;
public class SchemeDto : IMapFrom<SchemeEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }
}