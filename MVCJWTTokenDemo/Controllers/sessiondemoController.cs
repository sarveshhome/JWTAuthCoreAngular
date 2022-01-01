using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJWTTokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sessiondemoController : ControllerBase
    {
        private ILogger _logger= default(ILogger);
        sessiondemoController(ILogger<sessiondemoController> logger)
        {
            _logger = logger;
            HttpContext.Session.SetString("sessionname", "sarvesh");
        }
        /// <summary>
        /// Get Session
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/getsession")]
        public IActionResult GetSession()
        {
            string getValue = HttpContext.Session.GetString("sessionname");
            _logger.LogInformation("Get Value form session :" + getValue);
            return Ok(getValue);
        }
    }
}
