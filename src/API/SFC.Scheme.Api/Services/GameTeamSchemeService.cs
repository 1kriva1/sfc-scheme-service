using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;
using SFC.Scheme.Contracts.Headers;
using SFC.Scheme.Contracts.Messages.Scheme.Game.Team.Find;
using SFC.Scheme.Contracts.Messages.Scheme.Game.Team.Get;
using SFC.Scheme.Infrastructure.Constants;

using static SFC.Scheme.Contracts.Services.GameTeamSchemeService;

namespace SFC.Scheme.Api.Services;

[Authorize(Policy.General)]
public class GameTeamSchemeService(IMapper mapper, ISender mediator) : GameTeamSchemeServiceBase
{
    public override async Task<GetGameTeamSchemeResponse> GetGameTeamScheme(GetGameTeamSchemeRequest request, ServerCallContext context)
    {
        GetGameTeamSchemeQuery query = mapper.Map<GetGameTeamSchemeQuery>(request);

        GetGameTeamSchemeViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Scheme));

        return mapper.Map<GetGameTeamSchemeResponse>(model);
    }

    public override async Task<GetGameTeamSchemesResponse> GetGameTeamSchemes(GetGameTeamSchemesRequest request, ServerCallContext context)
    {
        GetGameTeamSchemesQuery query = mapper.Map<GetGameTeamSchemesQuery>(request);

        GetGameTeamSchemesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGameTeamSchemesResponse>(result);
    }
}