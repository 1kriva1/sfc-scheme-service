using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;
public class CreateGameTeamSchemeCommandHandler(
    IMapper mapper,
    IGameTeamSchemeRepository gameTeamSchemeRepository)
    : IRequestHandler<CreateGameTeamSchemeCommand, CreateGameTeamSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamSchemeRepository _gameTeamSchemeRepository = gameTeamSchemeRepository;

    public async Task<CreateGameTeamSchemeViewModel> Handle(CreateGameTeamSchemeCommand request, CancellationToken cancellationToken)
    {
        GameTeamScheme scheme = _mapper.Map<GameTeamScheme>(request.Scheme);

        scheme.AddDomainEvent(new GameTeamSchemeCreatedEvent(scheme));

        await _gameTeamSchemeRepository.AddAsync(scheme).ConfigureAwait(false);

        GameTeamScheme result = await _gameTeamSchemeRepository.GetByIdAsync(scheme.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        return _mapper.Map<CreateGameTeamSchemeViewModel>(result);
    }
}