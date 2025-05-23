using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;
using SFC.Scheme.Contracts.Messages.Scheme.Data.GetAll;
using SFC.Scheme.Infrastructure.Constants;

using static SFC.Scheme.Contracts.Services.SchemeDataService;

namespace SFC.Scheme.Api.Services;

[Authorize(Policy.General)]
public class SchemeDataService(IMapper mapper, ISender mediator) : SchemeDataServiceBase
{
    public override async Task<GetAllSchemeDataResponse> GetAll(GetAllSchemeDataRequest request, ServerCallContext context)
    {
        GetAllSchemeDataQuery query = new();

        GetAllSchemeDataViewModel model = await mediator.Send(query).ConfigureAwait(true);

        return mapper.Map<GetAllSchemeDataResponse>(model);
    }
}