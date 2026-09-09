using SFC.Scheme.Application.Common.Dto.Data;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Data;

namespace SFC.Scheme.Application.Features.Game.Data.Common.Dto;
public class GameStatusDto : DataDto, IMapTo<GameStatus> { }