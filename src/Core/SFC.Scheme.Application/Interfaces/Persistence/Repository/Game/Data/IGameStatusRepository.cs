using SFC.Scheme.Domain.Entities.Game.Data;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Data;
public interface IGameStatusRepository : IGameDataRepository<GameStatus, GameStatusEnum> { }