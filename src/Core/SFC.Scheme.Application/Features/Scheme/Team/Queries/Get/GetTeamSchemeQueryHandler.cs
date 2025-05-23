using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;
public class GetTeamSchemeQueryHandler(IMapper mapper, ITeamSchemeRepository schemeRepository)
    : IRequestHandler<GetTeamSchemeQuery, GetTeamSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSchemeRepository _schemeRepository = schemeRepository;

    public async Task<GetTeamSchemeViewModel> Handle(GetTeamSchemeQuery request, CancellationToken cancellationToken)
    {
        TeamScheme scheme = await _schemeRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        return _mapper.Map<GetTeamSchemeViewModel>(scheme);
    }
}