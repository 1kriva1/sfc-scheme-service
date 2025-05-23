using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;
public class FormationDataValueDto : DataValueDto, IMapFrom<Formation>
{
    public IEnumerable<IEnumerable<int>> Values { get; set; } = [];
}