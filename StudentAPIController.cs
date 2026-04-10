using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentTask.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentTask.Controllers
{
    //[Authorize]   //  PROTECT ALL APIs
    [ApiController]
    [Route("api/[controller]")]
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentAPIController(IStudentService service)
        {
            _service = service;
        }

        //  LOGIN API (NO TOKEN REQUIRED)
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] StudentTask.Models.LoginRequest request)
        {
            
            if (request.Username != "Akanksha" || request.Password != "Akshu123")
            {
                return Unauthorized("Invalid credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("thisIsMyVeryStrongSecretKey123456789");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, request.Username)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "yourIssuer",
                Audience = "yourAudience",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return Ok(new { token = jwtToken });
        }

        //  GET ALL
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _service.GetStudents());
        }

        //  GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _service.GetStudent(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        //  CREATE
        [HttpPost]
        public async Task<IActionResult> CreateStudent(TblStudent std)
        {
            return Ok(await _service.Create(std));
        }

        //  UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, TblStudent std)
        {
            if (id != std.Id) return BadRequest();
            return Ok(await _service.Update(std));
        }

        //  DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.Delete(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}