using Microsoft.Extensions.DependencyInjection;
using PSDinner.Application.Authentication;

namespace PSDinner.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
        return services;
    }
}