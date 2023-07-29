using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SyaaraatTask.BLL.Services.IServices;
using SyaaraatTask.DAL.Entities;
using SyaaraatTask.DAL.Repositories.IRepositories;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;
using TH = System.Threading.Tasks;

namespace SyaaraatTask.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<UserService> logger
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<UserDTO>> GetUsersAsync(
        CancellationToken cancellationToken = default
    )
    {
        var PersonsToReturn = await _unitOfWork.User.GetListAsync(
            cancellationToken: cancellationToken
        );
        _logger.LogInformation("List of {Count} Persons has been returned", PersonsToReturn.Count);

        return _mapper.Map<List<UserDTO>>(PersonsToReturn);
    }

    public async Task<UserDTO> GetUserAsync(
        int PersonId,
        CancellationToken cancellationToken = default
    )
    {
        _logger.LogInformation("Person with PersonId = {PersonId} was requested", PersonId);
        var PersonToReturn = await _unitOfWork.User.GetAsync(
            x => x.UserId == PersonId,
            cancellationToken
        );

        if (PersonToReturn is null)
        {
            _logger.LogError("Person with PersonId = {PersonId} was not found", PersonId);
            throw new UserNotFoundException();
        }
        var personDTO = _mapper.Map<UserDTO>(PersonToReturn);


        return personDTO;
    }

    public async Task<List<UserDTO>> FilterUserAsync(
        string SearchFor,
        CancellationToken cancellationToken = default
    )
    {
        var PersonsToReturn = await _unitOfWork.User.GetListAsync(
            x => EF.Functions.Like(x.Name, $"%{SearchFor}%"),
            cancellationToken
        );
        _logger.LogInformation("List of {Count} Persons has been returned", PersonsToReturn.Count);

        return _mapper.Map<List<UserDTO>>(PersonsToReturn);
    }

    public async Task<UserDTO> AddUserAsync(UserToAddDTO PersonToAddDTO)
    {

        var addedPerson = await _unitOfWork.User.AddAsync(_mapper.Map<User>(PersonToAddDTO));
        _unitOfWork.Save();
        return _mapper.Map<UserDTO>(addedPerson);
    }

    public async Task<UserDTO> UpdateUserAsync(UserToUpdateDTO UserToUpdateDTO)
    {
        UserToUpdateDTO.Username = UserToUpdateDTO.Username.ToLower();
        var oldUser = await _unitOfWork.User.GetAsync(
            x => x.UserId == UserToUpdateDTO.UserId
        );

        if (oldUser is null)
        {
            _logger.LogError(
                "User with UserId = {UserId} was not found",
                UserToUpdateDTO.UserId
            );
            throw new UserNotFoundException();
        }

        var UserToUpdate = _mapper.Map<User>(UserToUpdateDTO);

        _logger.LogInformation(
            "User with these properties: {@UserToUpdate} has been updated",
            UserToUpdateDTO
        );
        var User = await _unitOfWork.User.UpdateUserAsync(UserToUpdate);
        var per = _mapper.Map<UserDTO>(User);
        _unitOfWork.Save();
        return per;
    }

    public async TH.Task DeleteUserAsync(int UserId)
    {
        var UserToDelete = await _unitOfWork.User.GetAsync(x => x.UserId == UserId);

        if (UserToDelete is null)
        {
            _logger.LogError("User with UserId = {UserId} was not found", UserId);
            throw new UserNotFoundException();
        }

        await _unitOfWork.User.DeleteAsync(UserToDelete);
        _unitOfWork.Save();
    }
}
