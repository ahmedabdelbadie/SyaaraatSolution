using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Entities;

namespace SyaaraatTask.DAL.Repositories.IRepositories;

public class TaskRepository : GenericRepository<AssignTask>, ITaskRepository
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;

    public TaskRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
        : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }
}
