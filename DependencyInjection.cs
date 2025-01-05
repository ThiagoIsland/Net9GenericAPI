using GenericAPI.Application;
using GenericAPI.Core.Repository;
using GenericAPI.Infrastructure.Data;
using GenericAPI.Infrastructure.Repository;
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
        services.AddTransient<IGenericRepository, GenericRepository>();

        return services;
    }
}