using AutoMapper;

using MassTransit;

using SFC.Scheme.Application.Interfaces.Common;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;
using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Messages.Events.Scheme;

namespace SFC.Scheme.Infrastructure.Services.Scheme;
public class SchemeSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    ISchemeRepository schemeRepository) : ISchemeSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly ISchemeRepository _schemeRepository = schemeRepository;

    #region Stub data

    private static readonly List<long> IDS = [];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<SchemeEntity>> GetSeedSchemesAsync()
    {
        //return await _schemeRepository.GetByIdsAsync().ConfigureAwait(true);
        return await Task.FromResult<IEnumerable<SchemeEntity>>([]).ConfigureAwait(true);
    }

    public async Task SeedSchemesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<SchemeEntity> schemes = await CreateSeedSchemesAsync().ConfigureAwait(true);

        SchemeEntity[] seedSchemes = await
            _schemeRepository.AddRangeIfNotExistsAsync([.. schemes]).ConfigureAwait(true);

        await PublishSchemesSeededEventAsync(seedSchemes, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.Scheme, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<SchemeEntity>> CreateSeedSchemesAsync()
    {
        List<SchemeEntity> result = [];

        foreach (long item in IDS)
        {
            IEnumerable<SchemeEntity> part = await BuildSchemeAsync(item).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<SchemeEntity>> BuildSchemeAsync(long id)
    {
        DateTime createdDate = _dateTimeService.Now;

        // TODO
        Guid userId = Guid.NewGuid();

        SchemeEntity scheme = new()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
        };

        return await Task.FromResult(new List<SchemeEntity> { scheme }).ConfigureAwait(true);
    }

    private Task PublishSchemesSeededEventAsync(IEnumerable<SchemeEntity> schemes, CancellationToken cancellationToken = default)
    {
        SchemesSeeded @event = _mapper.Map<SchemesSeeded>(schemes);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}