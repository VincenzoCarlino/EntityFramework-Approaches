namespace UsersSample.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using UsersSample.Application.DTO.Users;
using UsersSample.Application.Services;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
public class UsersController : Controller
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("simple")]
    [Produces("application/json")]
    public Task<ActionResult<IEnumerable<UserSimpleOutput>>> GetUsersSimpleAsync()
        => _usersService.GetUsersSimpleOutputAsync()
            .ContinueWith<ActionResult<IEnumerable<UserSimpleOutput>>>(
                usersSimpleOutputTaskResult => new JsonResult(usersSimpleOutputTaskResult.Result)
                {
                    StatusCode = 200
                }
            );

    [HttpGet("list-view")]
    [Produces("application/json")]
    public Task<ActionResult<IEnumerable<UserWithRolesOutput>>> GetUsersWithRolesOutputAsync()
        => _usersService.GetUsersWithRolesOutputAsync()
            .ContinueWith<ActionResult<IEnumerable<UserWithRolesOutput>>>(
                usersWithRolesOutputTaskResult => new JsonResult(usersWithRolesOutputTaskResult.Result)
                {
                    StatusCode = 200
                }
            );
}