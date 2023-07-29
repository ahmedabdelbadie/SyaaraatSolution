
using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Repositories.IRepositories;

namespace SyaaraatTask.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private AspNetCoreTasksDbContext _context;

    private IUserRepository _userRepository = null;
    public UnitOfWork(AspNetCoreTasksDbContext context)
    {
        _context = context;

        Employee = new EmployeeRepository(context);
        Task = new TaskRepository(context);
        Department = new DepartmentRepository(context);
    }


    public IUserRepository User
    {
        get { return _userRepository != null ? _userRepository : new UserRepository(_context); }
    }
    public IEmployeeRepository Employee
    {
        get;
        private set;
    }
    public ITaskRepository Task
    {
        get;
        private set;
    }
    public IDepartmentRepository Department
    {
        get;
        private set;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
}
