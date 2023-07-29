using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SyaaraatTask.BLL.Services.IServices;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.API.Controllers;
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService PersonService)
    {
        _userService = PersonService;
    }

    [HttpGet("getPersons")]
    public async Task<IActionResult> GetPersons()
    {
        try
        {
            return Ok(await _userService.GetUsersAsync());
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpGet("getPerson")]
    public async Task<IActionResult> GetPerson(int PersonId, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _userService.GetUserAsync(PersonId, cancellationToken));
        }
        catch (UserNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpGet("filterPerson")]
    public async Task<IActionResult> FilterPerson(
        string SearchFor,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return Ok(await _userService.FilterUserAsync(SearchFor, cancellationToken));
        }
        catch (UserNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPost("addPerson")]
    public async Task<IActionResult> AddPerson(UserToAddDTO PersonToAddDTO)
    {
        try
        {
            return Ok(await _userService.AddUserAsync(PersonToAddDTO));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPut("updatePerson")]
    public async Task<IActionResult> UpdatePerson(UserToUpdateDTO PersonToUpdateDTO)
    {
        try
        {
            return Ok(await _userService.UpdateUserAsync(PersonToUpdateDTO));
        }
        catch (UserNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpDelete("deletePerson")]
    public async Task<IActionResult> DeletePerson(int PersonId)
    {
        try
        {
            await _userService.DeleteUserAsync(PersonId);
            return Ok();
        }
        catch (UserNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
