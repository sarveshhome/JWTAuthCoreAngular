using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCJWTTokenDemo.DAL;
using MVCJWTTokenDemo.Model;

namespace MVCJWTTokenDemo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private PatientDbContext _db = null;
        private ILogger _logger;
        public PatientController(PatientDbContext db, ILogger<PatientController> logger)
        {
            _db = db;
            _logger = logger;
            db.Database.EnsureCreated();
        }        
        [HttpPost("/api/patient")]
        public IActionResult AddPatient(Patient patientObj)
        {
            _logger.LogInformation("Add Patient");
            _db.Patients.Add(patientObj); //in memory
            _db.SaveChanges(); //physical commit 
            return Content("result");
        }
    }
}