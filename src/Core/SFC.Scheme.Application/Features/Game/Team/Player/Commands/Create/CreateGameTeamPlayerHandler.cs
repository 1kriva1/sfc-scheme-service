using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Create;
public class CreateGameTeamPlayerHandler(
    IMapper mapper,
    IGameTeamPlayerRepository gameTeamPlayerRepository)
    : IRequestHandler<CreateGameTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamPlayerRepository _gameTeamPlayerRepository = gameTeamPlayerRepository;

    public async Task Handle(CreateGameTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        GameTeamPlayer gameTeamPlayer = _mapper.Map<GameTeamPlayer>(request.GameTeamPlayer);

        await _gameTeamPlayerRepository.AddAsync(gameTeamPlayer)
                                 .ConfigureAwait(true);
    }
}