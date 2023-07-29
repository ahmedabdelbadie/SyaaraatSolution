using SyaaraatTask.DAL.Entities;

namespace SyaaraatTask.DAL.Repositories.IRepositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> UpdateUserAsync(User user);
}
