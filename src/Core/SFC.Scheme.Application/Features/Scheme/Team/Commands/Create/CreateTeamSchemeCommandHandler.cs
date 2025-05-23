using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Domain.Events.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
public class CreateTeamSchemeCommandHandler(
    IMapper mapper,
    ITeamSchemeRepository teamSchemeRepository)
    : IRequestHandler<CreateTeamSchemeCommand, CreateTeamSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSchemeRepository _teamSchemeRepository = teamSchemeRepository;

    public async Task<CreateTeamSchemeViewModel> Handle(CreateTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        TeamScheme scheme = _mapper.Map<TeamScheme>(request.Scheme);

        scheme.AddDomainEvent(new TeamSchemeCreatedEvent(scheme));

        await _teamSchemeRepository.AddAsync(scheme).ConfigureAwait(false);

        return _mapper.Map<CreateTeamSchemeViewModel>(scheme);
    }
}