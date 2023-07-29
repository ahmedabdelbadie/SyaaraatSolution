namespace SyaaraatTask.DAL.Repositories.IRepositories;


public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }
    IEmployeeRepository Employee { get; }
    ITaskRepository Task { get; }
    IDepartmentRepository Department { get; }
    int Save();
}

