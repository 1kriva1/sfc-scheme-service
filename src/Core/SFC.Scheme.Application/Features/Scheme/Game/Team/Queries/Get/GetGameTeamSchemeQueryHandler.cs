using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;
public class GetGameTeamSchemeQueryHandler(IMapper mapper, IGameTeamSchemeRepository gameTeamSchemeRepository)
    : IRequestHandler<GetGameTeamSchemeQuery, GetGameTeamSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamSchemeRepository _gameTeamSchemeRepository = gameTeamSchemeRepository;

    public async Task<GetGameTeamSchemeViewModel> Handle(GetGameTeamSchemeQuery request, CancellationToken cancellationToken)
    {
        GameTeamScheme scheme = await _gameTeamSchemeRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        return _mapper.Map<GetGameTeamSchemeViewModel>(scheme);
    }
}