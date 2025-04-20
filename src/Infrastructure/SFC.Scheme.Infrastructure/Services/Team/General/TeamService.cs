﻿using AutoMapper;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Interfaces.Team.General;
using SFC.Scheme.Infrastructure.Extensions.Grpc;
using SFC.Team.Contracts.Messages.Get;

using static SFC.Team.Contracts.Services.TeamService;

namespace SFC.Scheme.Infrastructure.Services.Team.General;
public class TeamService(
    TeamServiceClient client,
    IMapper mapper,
    IConfiguration configuration) : ITeamService
{
    private readonly TeamServiceClient _client = client;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;

    public async Task<TeamDto?> GetTeamAsync(long id, CancellationToken cancellationToken = default)
    {
        GetTeamRequest request = _mapper.Map<GetTeamRequest>(id);

        return await GrpcClientExtensions.CallWithAuditableAsync(
            _client.GetTeamAsync,
            request,
            _configuration,
            (response) => _mapper.Map<TeamDto>(response.Team),
            null,
            cancellationToken).ConfigureAwait(true);
    }
}