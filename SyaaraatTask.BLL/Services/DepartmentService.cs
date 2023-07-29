using SyaaraatTask.BLL.Services.IServices;
using SyaaraatTask.DTO.DTOs;
using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.BLL.Services;

public class DepartmentService : IDepartmentService
{
    public Task<DepartmentDTO> AddDepartmentAsync(UserToAddDTO UserToAddDTO)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task DeleteDepartmentAsync(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<List<DepartmentDTO>> FilterDepartmentAsync(string SearchFor, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DepartmentDTO> GetDepartmentAsync(int UserId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<DepartmentDTO>> GetDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DepartmentDTO> UpdateDepartmentAsync(UserToUpdateDTO UserToUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
