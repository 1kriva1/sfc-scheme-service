using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Update;
public class UpdateGameTeamPlayerHandler(IMapper mapper, IGameTeamPlayerRepository gameTeamPlayerRepository)
    : IRequestHandler<UpdateGameTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamPlayerRepository _gameTeamPlayerRepository = gameTeamPlayerRepository;

    public async Task Handle(UpdateGameTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        GameTeamPlayer gameTeamPlayer = await _gameTeamPlayerRepository
            .GetByIdAsync(request.GameTeamPlayer.GameId, request.GameTeamPlayer.TeamId, request.GameTeamPlayer.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.GameTeamPlayerNotFound);

        GameTeamPlayer updatedGameTeamPlayer = _mapper.Map(request.GameTeamPlayer, gameTeamPlayer);

        await _gameTeamPlayerRepository.UpdateAsync(updatedGameTeamPlayer)
                                   .ConfigureAwait(false);
    }
}