using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;
public class FormationPositionDataValueDto : DataValueDto, IMapFrom<FormationPosition>
{
    public int FootballPositionId { get; set; }
}