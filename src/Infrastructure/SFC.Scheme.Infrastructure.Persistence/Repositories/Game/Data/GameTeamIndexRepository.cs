using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Data;
public class GameTeamIndexRepository(GameDbContext context)
    : GameDataRepository<GameTeamIndex, GameTeamIndexEnum>(context), IGameTeamIndexRepository
{ }