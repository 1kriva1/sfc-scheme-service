using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Exceptions;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;
using SFC.Scheme.Domain.Events.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Update;
public class UpdateSchemeCommandHandler(IMapper mapper, ISchemeRepository schemeRepository)
    : IRequestHandler<UpdateSchemeCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeRepository _schemeRepository = schemeRepository;

    public async Task Handle(UpdateSchemeCommand request, CancellationToken cancellationToken)
    {
        SchemeEntity scheme = await _schemeRepository.GetByIdAsync(request.SchemeId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.SchemeNotFound);

        SchemeEntity updatedScheme = _mapper.Map(request.Scheme, scheme);

        updatedScheme.AddDomainEvent(new SchemeUpdatedEvent(updatedScheme));

        await _schemeRepository.UpdateAsync(updatedScheme)
                                        .ConfigureAwait(false);
    }
}