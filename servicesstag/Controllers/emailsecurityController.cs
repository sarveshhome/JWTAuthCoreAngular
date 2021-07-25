using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using servicesstag.Model;

namespace servicesstag.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class emailsecurityController : ControllerBase
    {
        private ILogger _logger;
        public emailsecurityController(ILogger<emailsecurityController> logger)
        {
            _logger = logger;            

        }
        [HttpPost("/api/email")]
        public IActionResult AddPatient(Email emailObj)
        {
            _logger.LogInformation("Add Email"); 


            return Content("result");
        }
    }
}