using CsvHandler.Core.Domain.Constants;
using CsvHandler.Core.ServiceContracts;
using CsvHandler.Core.Users.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CsvHandler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserUploadService usersService, IGetAllUsersService getAllUsersService) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile? file)
    {
        if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

        var result = await usersService.UploadUsersToDatabase(file);

        return Ok($"File uploaded successfully. New users added {result.NewUsers.Count}, " +
                  $"existing users updated {result.ExistingUsers.Count}");
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] QueryParams query)
    {
        return await getAllUsersService.GetAllMatchingUsers(query);
    }
}