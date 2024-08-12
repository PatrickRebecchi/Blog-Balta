using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

public class UserController : Controller
{
    [HttpGet("/usuarios")]
    [HttpGet("/users")]
    public async Task<IActionResult> GetAsync
        ([FromServices]BlogDataContext context)
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }
}
