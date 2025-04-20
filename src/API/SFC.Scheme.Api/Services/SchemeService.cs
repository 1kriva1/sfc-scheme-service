using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Application.Features.Scheme.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Queries.Get;
using SFC.Scheme.Contracts.Headers;
using SFC.Scheme.Contracts.Messages.Find;
using SFC.Scheme.Contracts.Messages.Get;
using SFC.Scheme.Infrastructure.Constants;

using static SFC.Scheme.Contracts.Services.SchemeService;

namespace SFC.Scheme.Api.Services;

[Authorize(Policy.General)]
public class SchemeService(IMapper mapper, ISender mediator) : SchemeServiceBase
{
    public override async Task<GetSchemeResponse> GetScheme(GetSchemeRequest request, ServerCallContext context)
    {
        GetSchemeQuery query = mapper.Map<GetSchemeQuery>(request);

        GetSchemeViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Scheme));

        return mapper.Map<GetSchemeResponse>(model);
    }

    public override async Task<GetSchemesResponse> GetSchemes(GetSchemesRequest request, ServerCallContext context)
    {
        GetSchemesQuery query = mapper.Map<GetSchemesQuery>(request);

        GetSchemesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetSchemesResponse>(result);
    }
}