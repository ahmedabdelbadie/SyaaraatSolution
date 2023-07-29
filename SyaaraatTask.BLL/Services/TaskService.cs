using SyaaraatTask.BLL.Services.IServices;
using SyaaraatTask.DTO.DTOs;
using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.BLL.Services;

public class TaskService : ITaskService
{
    public Task<EmployeeDTO> AddTaskAsync(UserToAddDTO UserToAddDTO)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task DeleteTaskAsync(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDTO>> FilterTaskAsync(string SearchFor, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> GetTaskAsync(int UserId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDTO>> GetTasksAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> UpdateTaskAsync(UserToUpdateDTO UserToUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
