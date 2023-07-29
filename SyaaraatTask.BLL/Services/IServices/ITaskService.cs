using SyaaraatTask.DTO.DTOs;
using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;
namespace SyaaraatTask.BLL.Services.IServices;

public interface ITaskService
{
    T.Task<List<EmployeeDTO>> GetTasksAsync(CancellationToken cancellationToken = default);
    T.Task<List<EmployeeDTO>> FilterTaskAsync(
        string SearchFor,
        CancellationToken cancellationToken = default
    );
    T.Task<EmployeeDTO> GetTaskAsync(int UserId, CancellationToken cancellationToken = default);
    T.Task<EmployeeDTO> AddTaskAsync(UserToAddDTO UserToAddDTO);
    T.Task<EmployeeDTO> UpdateTaskAsync(UserToUpdateDTO UserToUpdateDTO);
    T.Task DeleteTaskAsync(int UserId);
}
