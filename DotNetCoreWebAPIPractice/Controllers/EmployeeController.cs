using DotNetCoreWebAPIPractice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private ILogger _logger;
        private IEmployee _service;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployee service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("/api/employee")]
        public IEnumerable<string> getEmployee()
        {
            var objemployee =new [] {"sarvesh", "prashant" };
            _logger.LogInformation("get employee data" + objemployee);
            return objemployee;
        }
        [HttpPost("/api/employee")]
        public string postEmployee(IEmployee objIemployee)
        {
            return "";
        }

        //public HttpResponseMessage AddPatients()
        //{
        //    return actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //}
    }
}
