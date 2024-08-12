using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

public class PostController : Controller
{
    [HttpGet("/posts")]
    public async Task<IActionResult> GetAsync
        ([FromServices]BlogDataContext context)
    {
        var posts = await context.Posts.ToListAsync();
        return Ok(posts);
    }
}
