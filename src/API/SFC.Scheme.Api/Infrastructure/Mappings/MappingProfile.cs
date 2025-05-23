using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Scheme.Api.Infrastructure.Mappings.Converters;
using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Base;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Dto.Pagination;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;
using SFC.Scheme.Contracts.Models.Common;

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

        CreateMap<IEnumerable<int>, Int32Array>().ConvertUsing<Int32ArrayConverter>();

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        // data
        CreateMapSchemeDataContracts();

        // contracts
        CreateMapTeamSchemeContracts();

        #endregion Complex types        
    }

    private void CreateMapSchemeDataContracts()
    {
        CreateMap<DataValueDto, SFC.Scheme.Contracts.Models.Scheme.Data.DataValue>();
        CreateMap<FormationPositionDataValueDto, SFC.Scheme.Contracts.Models.Scheme.Data.FormationPositionDataValue>()
            .ForMember(p => p.FootballPosition, d => d.MapFrom(z => z.FootballPositionId));
        CreateMap<FormationDataValueDto, SFC.Scheme.Contracts.Models.Scheme.Data.FormationDataValue>();
        CreateMap<GetAllSchemeDataViewModel, SFC.Scheme.Contracts.Messages.Scheme.Data.GetAll.GetAllSchemeDataResponse>();
    }

    private void CreateMapTeamSchemeContracts()
    {
        // team scheme
        CreateMap<TeamSchemeDto, SFC.Scheme.Contracts.Models.Scheme.Team.TeamScheme>();
        CreateMap<TeamSchemeGeneralProfileDto, SFC.Scheme.Contracts.Models.Scheme.Team.TeamSchemeGeneralProfile>()
            .ForMember(p => p.Formation, d => d.MapFrom(z => z.FormationId))
            .ForMember(p => p.Type, d => d.MapFrom(z => z.TypeId));
        CreateMap<TeamSchemePlayerDto, SFC.Scheme.Contracts.Models.Scheme.Team.TeamSchemePlayer>();
        CreateMap<TeamSchemePlayerPositionDto, SFC.Scheme.Contracts.Models.Scheme.Team.TeamSchemePlayerPosition>()
            .ForMember(p => p.FormationPosition, d => d.MapFrom(z => z.FormationPositionId));
        CreateMap<TeamSchemeProfileDto, SFC.Scheme.Contracts.Models.Scheme.Team.TeamSchemeProfile>();

        // get team scheme        
        CreateMap<GetTeamSchemeViewModel, SFC.Scheme.Contracts.Messages.Scheme.Team.Get.GetTeamSchemeResponse>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Get.GetTeamSchemeRequest, GetTeamSchemeQuery>();
        CreateMap<TeamSchemeDto, SFC.Scheme.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get schemes
        // (filters)
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.GetTeamSchemesRequest, GetTeamSchemesQuery>();
        CreateMap<SFC.Scheme.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Scheme.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.Filters.GetTeamSchemesFilter, GetTeamSchemesFilterDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.Filters.TeamSchemesGeneralProfileFilter, GetTeamSchemesGeneralProfileFilterDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.Filters.TeamSchemesPlayersFilter, GetTeamSchemesPlayersFilterDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.Filters.TeamSchemesPlayersStatsFilter, GetTeamSchemesPlayersStatsFilterDto>();
        CreateMap<SFC.Scheme.Contracts.Messages.Scheme.Team.Find.Filters.TeamSchemesProfileFilter, GetTeamSchemesProfileFilterDto>();
        CreateMap(typeof(SFC.Scheme.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetTeamSchemesViewModel, SFC.Scheme.Contracts.Messages.Scheme.Team.Find.GetTeamSchemesResponse>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Scheme.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}