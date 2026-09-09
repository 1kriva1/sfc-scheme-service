using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Features.Common.Dto.Pagination;
using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Filters;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Extensions;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Extensions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;
public class GetGameTeamSchemesQueryHandler(
    IMapper mapper,
    IGameTeamSchemeRepository gameTeamSchemeRepository)
    : IRequestHandler<GetGameTeamSchemesQuery, GetGameTeamSchemesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamSchemeRepository _gameTeamSchemeRepository = gameTeamSchemeRepository;

    public async Task<GetGameTeamSchemesViewModel> Handle(GetGameTeamSchemesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GameTeamScheme>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<GameTeamScheme, dynamic>>? sorting = request.Sorting.BuildGameTeamSchemeSearchSorting();

        FindParameters<GameTeamScheme> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GameTeamScheme>(filters),
            Sorting = new Sortings<GameTeamScheme>(sorting)
        };

        PagedList<GameTeamScheme> pageList = await _gameTeamSchemeRepository.FindAsync(parameters).ConfigureAwait(true);

        return new GetGameTeamSchemesViewModel
        {
            Items = _mapper.Map<IEnumerable<GameTeamSchemeDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}