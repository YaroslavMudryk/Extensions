using Extensions.Generator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Example.Controllers.V1
{
    [ApiVersion("1.0")]
    public class GeneratorsController : ApiBaseController
    {
        [HttpGet]
        public IActionResult GetRandomString(int l)
        {
            return Ok(new
            {
                result = RandomGenerator.GetString(l)
            });
        }

        [HttpGet("code")]
        public IActionResult GetStringCode()
        {
            return Ok(new
            {
                result = RandomGenerator.GetStringCode(6)
            });
        }

        [HttpGet("uniq")]
        public IActionResult GetUniqCode()
        {
            return Ok(RandomGenerator.GetUniqCode().ToUpper()); //8AJY-TM3S-9OX2-TGUW
        }
    }
}
