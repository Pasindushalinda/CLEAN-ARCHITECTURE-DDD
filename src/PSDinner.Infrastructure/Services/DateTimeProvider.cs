using System;
using PSDinner.Application.Common.Interfaces.Services;

namespace PSDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}