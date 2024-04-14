using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSDinner.Application.Common.Infrastructure.Authentication;
using PSDinner.Application.Common.Interfaces.Services;
using PSDinner.Infrastructure.Authentication;
using PSDinner.Infrastructure.Services;

namespace PSDinner.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}