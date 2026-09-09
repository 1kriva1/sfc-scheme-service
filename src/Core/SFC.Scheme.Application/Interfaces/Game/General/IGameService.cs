using SFC.Scheme.Application.Common.Dto.Game.General;

namespace SFC.Scheme.Application.Interfaces.Game.General;
public interface IGameService
{
    Task<GameDto?> GetGameAsync(long id, CancellationToken cancellationToken = default);
}