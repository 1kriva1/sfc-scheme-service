using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Common;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Extensions;

namespace SFC.Scheme.Infrastructure.Persistence.Seeds;
public static class SchemeDataSeed
{
    public static void SeedSchemeData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        builder.SeedDataEnumValues<SchemeType, SchemeTypeEnum>(@enum =>
            new SchemeType(@enum).SetCreatedDate(dateTimeService));
    }
}