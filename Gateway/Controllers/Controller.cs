using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;
[Route("api/controller/")]
[ApiController]
public class Controller : ControllerBase
{
    [HttpGet]
    [Route("hello")]
    public string HelloWorld()
    {
        return "Hello World";
    }
}