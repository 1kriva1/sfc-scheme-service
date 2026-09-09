using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;
public class UpdateGameTeamSchemeCommandHandler(IMapper mapper, IGameTeamSchemeRepository gameTeamSchemeRepository)
    : IRequestHandler<UpdateGameTeamSchemeCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamSchemeRepository _gameTeamSchemeRepository = gameTeamSchemeRepository;

    public async Task Handle(UpdateGameTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        GameTeamScheme scheme = await _gameTeamSchemeRepository.GetByIdAsync(request.Scheme.Id, request.Scheme.GameId, request.Scheme.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        GameTeamScheme updatedScheme = _mapper.Map(request.Scheme, scheme);

        updatedScheme.AddDomainEvent(new GameTeamSchemeUpdatedEvent(updatedScheme));

        await _gameTeamSchemeRepository.UpdateAsync(updatedScheme)
                                       .ConfigureAwait(false);
    }
}