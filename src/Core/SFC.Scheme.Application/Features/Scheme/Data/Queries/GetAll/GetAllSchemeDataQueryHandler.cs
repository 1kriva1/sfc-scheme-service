using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;
using SFC.Scheme.Application.Interfaces.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Scheme.Data.Models;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;

public class GetAllSchemeDataQueryHandler(IMapper mapper, ISchemeDataService schemeDataService)
    : IRequestHandler<GetAllSchemeDataQuery, GetAllSchemeDataViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeDataService _schemeDataService = schemeDataService;

    public async Task<GetAllSchemeDataViewModel> Handle(GetAllSchemeDataQuery request, CancellationToken cancellationToken)
    {
        GetAllSchemeDataModel model = await _schemeDataService.GetAllSchemeDataAsync().ConfigureAwait(true);

        return new GetAllSchemeDataViewModel
        {
            SchemeTypes = _mapper.Map<IEnumerable<DataValueDto>>(model.SchemeTypes.Localize()),
            FormationPositions = _mapper.Map<IEnumerable<FormationPositionDataValueDto>>(model.FormationPositions.Localize()),
            Formations = _mapper.Map<IEnumerable<FormationDataValueDto>>(model.Formations.Localize())
        };
    }
}