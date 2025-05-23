using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
public class CreateTeamSchemeDto : TeamSchemeDto, IMapTo<TeamScheme> { }