using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;

namespace SyaaraatTask.BLL.Services.IServices;

public interface IUserService
{
    T.Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default);
    T.Task<List<UserDTO>> FilterUserAsync(
        string SearchFor,
        CancellationToken cancellationToken = default
    );
    T.Task<UserDTO> GetUserAsync(int UserId, CancellationToken cancellationToken = default);
    T.Task<UserDTO> AddUserAsync(UserToAddDTO UserToAddDTO);
    T.Task<UserDTO> UpdateUserAsync(UserToUpdateDTO UserToUpdateDTO);
    T.Task DeleteUserAsync(int UserId);
}
