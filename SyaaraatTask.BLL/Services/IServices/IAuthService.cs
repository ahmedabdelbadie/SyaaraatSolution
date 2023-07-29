using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.BLL.Services.IServices;

public interface IAuthService
{
    Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO);
    Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO);
}
