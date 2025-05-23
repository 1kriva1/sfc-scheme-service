using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data;
public class SchemeTypeRepository(SchemeDbContext context)
    : SchemeDataRepository<SchemeType, SchemeTypeEnum>(context), ISchemeTypeRepository
{ }