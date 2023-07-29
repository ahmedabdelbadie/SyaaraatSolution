using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Entities;

namespace SyaaraatTask.DAL.Repositories.IRepositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;

    public DepartmentRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
        : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

}
