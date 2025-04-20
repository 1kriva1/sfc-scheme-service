using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Find;
public class GetSchemesQuery : BasePaginationRequest<GetSchemesViewModel, GetSchemesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetSchemes; }
}