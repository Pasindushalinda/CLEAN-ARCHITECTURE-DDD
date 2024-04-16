using Microsoft.AspNetCore.Mvc.Infrastructure;
using PSDinner.Api.Common.Mappings;
using PSDinner.Api.Errors;

namespace PSDinner.Api;

public static class PresentationServiceRegistration
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, ApplicationProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}