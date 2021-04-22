using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MVCJWTTokenDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class securityController : ControllerBase
    {
        public IConfiguration _config = null;

        public securityController(IConfiguration config)
        {
            _config = config;
        }       

        // Step 1 :- Generate 
        public string GenerateJSONWebToken()
        {
            // when he is validated AD
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "sar"),
                new Claim(JwtRegisteredClaimNames.Email, "sarveshmcasoft@gmail.com"),
                new Claim("Role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("/api/login")]
        public IActionResult Login(User user)
        {
            if (user.userName == "Sar")
            {
                string str = GenerateJSONWebToken();

                return Content(str);

                //return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Security issues");
            }
        }
    }

    public class User
    {
        public string userName { get; set; }
    }
}