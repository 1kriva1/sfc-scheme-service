using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data;
public class FormationPositionRepository(SchemeDbContext context)
    : SchemeDataRepository<FormationPosition, FormationPositionEnum>(context), IFormationPositionRepository
{ }