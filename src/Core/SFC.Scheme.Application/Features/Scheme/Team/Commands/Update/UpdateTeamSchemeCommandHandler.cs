using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Domain.Events.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;
public class UpdateTeamSchemeCommandHandler(IMapper mapper, ITeamSchemeRepository teamSchemeRepository)
    : IRequestHandler<UpdateTeamSchemeCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSchemeRepository _teamSchemeRepository = teamSchemeRepository;

    public async Task Handle(UpdateTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        TeamScheme scheme = await _teamSchemeRepository.GetByIdAsync(request.Scheme.Id, request.Scheme.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        TeamScheme updatedScheme = _mapper.Map(request.Scheme, scheme);

        updatedScheme.AddDomainEvent(new TeamSchemeUpdatedEvent(updatedScheme));

        await _teamSchemeRepository.UpdateAsync(updatedScheme)
                                   .ConfigureAwait(false);
    }
}