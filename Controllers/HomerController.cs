using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;


[ApiController]
[Route("")]
public class HomerController : ControllerBase
{
    [HttpGet("")]

    public IActionResult Get()
    {
        return Ok();
    }

    public string Index()
    {
        return "Hello, World!";
    }

    [HttpGet("/teste")]
    public string IndexTeste()
    {
        return "Vamos atualizar o conhhecimento";
    }
}
