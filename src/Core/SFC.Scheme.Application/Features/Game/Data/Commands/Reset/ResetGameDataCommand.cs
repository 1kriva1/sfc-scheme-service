using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Game.Data.Common.Dto;

namespace SFC.Scheme.Application.Features.Game.Data.Commands.Reset;
public class ResetGameDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetGameData; }

    public IEnumerable<GameStatusDto> GameStatuses { get; init; } = [];

    public IEnumerable<GameTeamStatusDto> GameTeamStatuses { get; init; } = [];

    public IEnumerable<GameTeamIndexDto> GameTeamIndexes { get; init; } = [];
}