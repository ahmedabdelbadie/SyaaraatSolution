using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SyaaraatTask.BLL.Services.IServices;

namespace Task.PersonAddress.API.Controllers.V2;

[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IUserService _userService;

    public PersonController(IUserService PersonService)
    {
        _userService = PersonService;
    }

    [HttpGet("getusers")]
    public async Task<IActionResult> GetPersons(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _userService.GetUsersAsync(cancellationToken));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
