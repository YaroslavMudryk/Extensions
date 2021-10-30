using Extensions.DeviceDetector;
using Microsoft.AspNetCore.Mvc;

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
    }
}
