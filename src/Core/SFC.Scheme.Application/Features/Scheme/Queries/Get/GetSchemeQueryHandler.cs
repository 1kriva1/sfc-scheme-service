using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Get;
public class GetSchemeQueryHandler(IMapper mapper, ISchemeRepository schemeRepository)
    : IRequestHandler<GetSchemeQuery, GetSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeRepository _schemeRepository = schemeRepository;

    public async Task<GetSchemeViewModel> Handle(GetSchemeQuery request, CancellationToken cancellationToken)
    {
        SchemeEntity scheme = await _schemeRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        return _mapper.Map<GetSchemeViewModel>(scheme);
    }
}