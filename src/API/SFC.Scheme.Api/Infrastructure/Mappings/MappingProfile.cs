using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Base;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Dto.Pagination;
using SFC.Scheme.Application.Features.Scheme.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Dto.Filters;
using SFC.Scheme.Application.Features.Scheme.Queries.Get;

namespace SFC.Scheme.Api.Infrastructure.Mappings;

public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types

        CreateMap<DateTime, Timestamp>()
            .ConvertUsing(value => DateTime.SpecifyKind(value, DateTimeKind.Utc).ToTimestamp());

        CreateMap<TimeSpan, Duration>()
            .ConvertUsing(value => Duration.FromTimeSpan(value));

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        // contracts
        CreateMapSchemeContracts();

        #endregion Complex types        
    }

    private void CreateMapSchemeContracts()
    {
        // get scheme
        CreateMap<SchemeDto, SFC.Scheme.Contracts.Models.Scheme.Scheme>();
        CreateMap<GetSchemeViewModel, SFC.Scheme.Contracts.Messages.Get.GetSchemeResponse>();
        CreateMap<SFC.Scheme.Contracts.Messages.Get.GetSchemeRequest, GetSchemeQuery>();
        CreateMap<SchemeDto, SFC.Scheme.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get schemes
        // (filters)
        CreateMap<SFC.Scheme.Contracts.Messages.Find.GetSchemesRequest, GetSchemesQuery>();
        CreateMap<SFC.Scheme.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Scheme.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Find.Filters.GetSchemesFilter, GetSchemesFilterDto>();
        CreateMap(typeof(SFC.Scheme.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetSchemesViewModel, SFC.Scheme.Contracts.Messages.Find.GetSchemesResponse>();
        CreateMap<SFC.Scheme.Application.Features.Scheme.Common.Dto.SchemeDto, SFC.Scheme.Contracts.Models.Scheme.Scheme>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Scheme.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}