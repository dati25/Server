using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using Server.Database.Models;
using Server.Results.LoginServices;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private MyContext context = new MyContext();
        [HttpGet("{IdPc}")]
        public IActionResult GetPcStatus(string IdPc)
        {
            var pc = this.context.Computers!.Find(IdPc);
            if (pc == null)
                return NotFound(new {message = "Object doesn't exist."});
            return Ok(pc.Status);
        }
        [HttpPost]
        public IActionResult Post(Login model)
        {
            try
            {
                Admin admin = this.context.Admins!.Where(x => x.Username == model.Username).First();

                if (BCrypt.Net.BCrypt.EnhancedVerify(model.Password, admin.Password))
                {
                    string token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm())
                      .WithSecret("MarcelJeGay123")
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                      .AddClaim("login", admin.Username)
                      .Encode();

                    return Ok(new { token = token });
                }

                return Unauthorized(new { message = "Invalid credentials" });
            }
            catch
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }

    }
}
