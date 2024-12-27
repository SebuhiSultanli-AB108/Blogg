using Blogg.Core.Repositories;
using Blogg.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blogg.DAL;

public static class ServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
