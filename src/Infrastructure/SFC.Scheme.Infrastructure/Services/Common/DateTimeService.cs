using SFC.Scheme.Application.Interfaces.Common;

namespace SFC.Scheme.Infrastructure.Services.Common;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime DateNow => DateTime.UtcNow.Date;
}