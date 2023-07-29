using SyaaraatTask.DTO.DTOs;

using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;
namespace SyaaraatTask.BLL.Services.IServices;

public interface IDepartmentService
{

    T.Task<List<DepartmentDTO>> GetDepartmentsAsync(CancellationToken cancellationToken = default);
    T.Task<List<DepartmentDTO>> FilterDepartmentAsync(
        string SearchFor,
        CancellationToken cancellationToken = default
    );
    T.Task<DepartmentDTO> GetDepartmentAsync(int UserId, CancellationToken cancellationToken = default);
    T.Task<DepartmentDTO> AddDepartmentAsync(UserToAddDTO UserToAddDTO);
    T.Task<DepartmentDTO> UpdateDepartmentAsync(UserToUpdateDTO UserToUpdateDTO);
    T.Task DeleteDepartmentAsync(int UserId);
}
