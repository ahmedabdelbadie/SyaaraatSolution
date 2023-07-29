using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Entities;

namespace SyaaraatTask.DAL.Repositories.IRepositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;

    public EmployeeRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
        : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }
}
