using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;
using SFC.Scheme.Domain.Events.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Create;
public class CreateSchemeCommandHandler(
    IMapper mapper,
    ISchemeRepository schemeRepository)
    : IRequestHandler<CreateSchemeCommand, CreateSchemeViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeRepository _schemeRepository = schemeRepository;

    public async Task<CreateSchemeViewModel> Handle(CreateSchemeCommand request, CancellationToken cancellationToken)
    {
        SchemeEntity scheme = _mapper.Map<SchemeEntity>(request.Scheme);

        scheme.AddDomainEvent(new SchemeCreatedEvent(scheme));

        await _schemeRepository.AddAsync(scheme)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateSchemeViewModel>(scheme);
    }
}