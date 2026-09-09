using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Scheme.Domain.Entities.Game.Team;

namespace SFC.Scheme.Application.Features.Game.Team.Commands.Create;
public class CreateGameTeamHandler(
    IMapper mapper,
    IGameTeamRepository gameTeamRepository)
    : IRequestHandler<CreateGameTeamCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRepository _gameTeamRepository = gameTeamRepository;

    public async Task Handle(CreateGameTeamCommand request, CancellationToken cancellationToken)
    {
        GameTeam gameTeam = _mapper.Map<GameTeam>(request.GameTeam);

        await _gameTeamRepository.AddAsync(gameTeam)
                                 .ConfigureAwait(true);
    }
}