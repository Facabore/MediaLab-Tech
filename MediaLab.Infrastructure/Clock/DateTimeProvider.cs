using MediaLab.Application.Abstractions.Clock;

namespace MediaLab.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}