using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Features.Common.Dto.Pagination;
using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Filters;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;
using SFC.Scheme.Application.Features.Scheme.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Extensions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Find;
public class GetSchemesQueryHandler(
    IMapper mapper,
    ISchemeRepository schemeRepository)
    : IRequestHandler<GetSchemesQuery, GetSchemesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeRepository _schemeRepository = schemeRepository;

    public async Task<GetSchemesViewModel> Handle(GetSchemesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<SchemeEntity>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<SchemeEntity, dynamic>>? sorting = request.Sorting.BuildSchemeSearchSorting();

        FindParameters<SchemeEntity> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<SchemeEntity>(filters),
            Sorting = new Sortings<SchemeEntity>(sorting)
        };

        PagedList<SchemeEntity> pageList = await _schemeRepository
                                                             .FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetSchemesViewModel
        {
            Items = _mapper.Map<IEnumerable<SchemeDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}