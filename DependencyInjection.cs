using GenericAPI.Application;
using GenericAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GenericAPI;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<BaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddTransient<IGenericService, GenericService>();

        return services;
    }
}