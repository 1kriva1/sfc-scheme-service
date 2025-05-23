using AutoMapper;

using MassTransit;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Scheme.Data.Models;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Messages.Events.Scheme.Data;

namespace SFC.Scheme.Infrastructure.Services.Scheme.Data;
public class SchemeDataService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IFormationRepository formationRepository,
    IFormationPositionRepository formationPositionRepository,
    ISchemeTypeRepository schemeTypeRepository) : ISchemeDataService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IFormationRepository _formationRepository = formationRepository;
    private readonly IFormationPositionRepository _formationPositionRepository = formationPositionRepository;
    private readonly ISchemeTypeRepository _schemeTypeRepository = schemeTypeRepository;

    public async Task<GetAllSchemeDataModel> GetAllSchemeDataAsync()
    {
        return new()
        {
            Formations = await _formationRepository.ListAllAsync().ConfigureAwait(false),
            FormationPositions = await _formationPositionRepository.ListAllAsync().ConfigureAwait(false),
            SchemeTypes = await _schemeTypeRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task PublishDataInitializedEventAsync(CancellationToken cancellationToken)
    {
        GetAllSchemeDataModel model = await GetAllSchemeDataAsync().ConfigureAwait(true);

        DataInitialized @event = _mapper.BuildSchemeDataInitializedEvent(model);

        await _publisher.Publish(@event, cancellationToken)
                        .ConfigureAwait(false);
    }
}