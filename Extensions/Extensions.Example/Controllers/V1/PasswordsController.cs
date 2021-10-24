using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extensions.Password;

namespace Extensions.Example.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PasswordsController : ApiBaseController
    {
        [HttpGet]
        public IActionResult GetPassHash(string q)
        {
            return Ok(new 
            {
                Password = q,
                Hash = q.GeneratePasswordHash()
            });
        }

        [HttpGet("verify")]
        public IActionResult VerifyPass(string q)
        {
            string check = "DotnetExtensions";
            return Ok(new
            {
                Password = q,
                CheckPassword = check,
                IsVerify = q.VerifyPasswordHash(check.GeneratePasswordHash())
            });
        }
    }
}
