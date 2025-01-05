using Blogg.BL.ExternalServices.JWTService;
using Blogg.BL.Services.CategoryService;
using Blogg.BL.Services.UserService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blogg.BL;

public static class ServiceRegistration
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJWTTokenHandler, JWTTokenHandler>();
        return services;
    }
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration));
        return services;
    }
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
        return services;
    }
}
