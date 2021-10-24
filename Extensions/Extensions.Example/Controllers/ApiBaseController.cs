using Microsoft.AspNetCore.Mvc;

namespace Extensions.Example.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {

    }
}
