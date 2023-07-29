using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Entities;
using SyaaraatTask.DAL.Repositories.IRepositories;

namespace SyaaraatTask.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;

    public UserRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
        : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

    public async Task<User> UpdateUserAsync(User User)
    {
        _ = _aspNetCoreNTierDbContext.Update(User);

        // Ignore password property update for user
        _aspNetCoreNTierDbContext.Entry(User).Property(x => x.Password).IsModified = false;

        return User;
    }
}
