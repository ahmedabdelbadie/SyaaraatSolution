using SyaaraatTask.BLL.Services.IServices;
using SyaaraatTask.DTO.DTOs;
using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.BLL.Services;

public class Employee : IEmployeeService
{
    public Task<EmployeeDTO> AddEmployeeAsync(UserToAddDTO UserToAddDTO)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task DeleteEmployeeAsync(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDTO>> FilterUserAsync(string SearchFor, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> GetEmployeeAsync(int UserId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> UpdateEmployeeAsync(UserToUpdateDTO UserToUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
