using SFC.Scheme.Application.Common.Dto.Data;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Application.Features.Data.Common.Dto;
public class StatTypeDto : DataDto, IMapTo<StatType>
{
    public int CategoryId { get; set; }

    public int SkillId { get; set; }
}