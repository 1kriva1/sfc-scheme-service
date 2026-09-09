using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Data;
public class GameTeamStatusRepository(GameDbContext context)
    : GameDataRepository<GameTeamStatus, GameTeamStatusEnum>(context), IGameTeamStatusRepository
{ }