﻿using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Domain.Entities.Team.Data;
using SFC.Scheme.Domain.Events.Team.Data;

namespace SFC.Scheme.Application.Features.Team.Data.Commands.Reset;

public class ResetTeamDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    ITeamPlayerStatusRepository teamPlayerStatusRepository) : IRequestHandler<ResetTeamDataCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly ITeamPlayerStatusRepository _teamPlayerStatusRepository = teamPlayerStatusRepository;

    public async Task Handle(ResetTeamDataCommand request, CancellationToken cancellationToken)
    {
        await _teamPlayerStatusRepository
            .ResetAsync(_mapper.Map<IEnumerable<TeamPlayerStatus>>(request.TeamPlayerStatuses))
            .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        TeamDataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}