using SFC.Scheme.Application.Common.Dto.Data;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Team.Data;

namespace SFC.Scheme.Application.Features.Team.Data.Common.Dto;
public class TeamPlayerStatusDto : DataDto, IMapTo<TeamPlayerStatus> { }