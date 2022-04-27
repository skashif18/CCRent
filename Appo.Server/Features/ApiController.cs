namespace Appo.Server.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public abstract class ApiController : ControllerBase
    {


    }
}
