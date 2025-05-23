using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;
using SFC.Scheme.Contracts.Headers;
using SFC.Scheme.Contracts.Messages.Scheme.Team.Find;
using SFC.Scheme.Contracts.Messages.Scheme.Team.Get;
using SFC.Scheme.Infrastructure.Constants;

using static SFC.Scheme.Contracts.Services.TeamSchemeService;

namespace SFC.Scheme.Api.Services;

[Authorize(Policy.General)]
public class TeamSchemeService(IMapper mapper, ISender mediator) : TeamSchemeServiceBase
{
    public override async Task<GetTeamSchemeResponse> GetTeamScheme(GetTeamSchemeRequest request, ServerCallContext context)
    {
        GetTeamSchemeQuery query = mapper.Map<GetTeamSchemeQuery>(request);

        GetTeamSchemeViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Scheme));

        return mapper.Map<GetTeamSchemeResponse>(model);
    }

    public override async Task<GetTeamSchemesResponse> GetTeamSchemes(GetTeamSchemesRequest request, ServerCallContext context)
    {
        GetTeamSchemesQuery query = mapper.Map<GetTeamSchemesQuery>(request);

        GetTeamSchemesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetTeamSchemesResponse>(result);
    }
}