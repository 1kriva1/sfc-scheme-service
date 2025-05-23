using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Features.Common.Dto.Pagination;
using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Filters;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Extensions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
public class GetTeamSchemesQueryHandler(
    IMapper mapper,
    ITeamSchemeRepository teamSchemeRepository)
    : IRequestHandler<GetTeamSchemesQuery, GetTeamSchemesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSchemeRepository _teamSchemeRepository = teamSchemeRepository;

    public async Task<GetTeamSchemesViewModel> Handle(GetTeamSchemesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<TeamScheme>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<TeamScheme, dynamic>>? sorting = request.Sorting.BuildSchemeSearchSorting();

        FindParameters<TeamScheme> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<TeamScheme>(filters),
            Sorting = new Sortings<TeamScheme>(sorting)
        };

        PagedList<TeamScheme> pageList = await _teamSchemeRepository.FindAsync(parameters).ConfigureAwait(true);

        return new GetTeamSchemesViewModel
        {
            Items = _mapper.Map<IEnumerable<TeamSchemeDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}