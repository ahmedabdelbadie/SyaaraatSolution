using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Repositories;
using SyaaraatTask.DAL.Repositories.IRepositories;

namespace SyaaraatTask.DAL;

public static class DependencyInjection
{
    public static void RegisterDALDependencies(
        this IServiceCollection services,
        IConfiguration Configuration
    )
    {
        services.AddDbContext<AspNetCoreTasksDbContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
