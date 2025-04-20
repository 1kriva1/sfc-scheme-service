using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data;
public class WorkingFootRepository(DataDbContext context)
    : DataRepository<WorkingFoot, WorkingFootEnum>(context), IWorkingFootRepository
{ }