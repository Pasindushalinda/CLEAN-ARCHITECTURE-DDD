using Microsoft.AspNetCore.Mvc.Infrastructure;
using PSDinner.Api.Errors;
using PSDinner.Application;
using PSDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddSingleton<ProblemDetailsFactory, ApplicationProblemDetailsFactory>();

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
