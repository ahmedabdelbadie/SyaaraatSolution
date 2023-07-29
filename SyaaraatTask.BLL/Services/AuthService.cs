using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SyaaraatTask.BLL.Services.IServices;
using SyaaraatTask.DAL.Entities;
using SyaaraatTask.DAL.Repositories.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IConfiguration configuration
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO)
    {
        var user = await _unitOfWork.User.GetAsync(
            u =>
                u.Email == userToLoginDTO.Email
                && u.Password == userToLoginDTO.Password
        );

        if (user == null)
            throw new UserNotFoundException();

        var userToReturn = _mapper.Map<UserToReturnDTO>(user);
        userToReturn.Token = GenerateToken(user.UserId, user.Email);

        return userToReturn;
    }

    public async Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO)
    {
        userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

        var addedUser = await _unitOfWork.User.AddAsync(_mapper.Map<User>(userToRegisterDTO));
        _unitOfWork.Save();
        var userToReturn = _mapper.Map<UserToReturnDTO>(addedUser);
        userToReturn.Token = GenerateToken(addedUser.UserId, addedUser.Email);

        return userToReturn;
    }

    private string GenerateToken(int userId, string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
