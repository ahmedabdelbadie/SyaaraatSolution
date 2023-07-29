using SyaaraatTask.DTO.DTOs;
using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;
namespace SyaaraatTask.BLL.Services.IServices;

public interface IEmployeeService
{

    T.Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellationToken = default);
    T.Task<List<EmployeeDTO>> FilterUserAsync(
        string SearchFor,
        CancellationToken cancellationToken = default
    );
    T.Task<EmployeeDTO> GetEmployeeAsync(int UserId, CancellationToken cancellationToken = default);
    T.Task<EmployeeDTO> AddEmployeeAsync(UserToAddDTO UserToAddDTO);
    T.Task<EmployeeDTO> UpdateEmployeeAsync(UserToUpdateDTO UserToUpdateDTO);
    T.Task DeleteEmployeeAsync(int UserId);
}
