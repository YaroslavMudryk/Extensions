using Extensions.DeviceDetector;
using Extensions.LinkPreview;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Extensions.Example.Controllers.V1
{
    [ApiVersion("1.0")]
    public class DetectorsController : ApiBaseController
    {
        private readonly IDetector _detector;
        public DetectorsController(IDetector detector)
        {
            _detector = detector;
        }

        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok(_detector.GetClientInfo());
        }

        [HttpGet("preview")]
        public async Task<IActionResult> GetLinkPreview(string q)
        {
            return Ok(await q.GetLinkInfoAsync());
        }
    }
}
