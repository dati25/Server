using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ConfigCommans;
using SeverAPI.Results.ConfigResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        // GET: api/<ConfigController>
        [HttpGet]
        public IActionResult Get()
        {
            ConfigCommandGet command = new ConfigCommandGet();
            List<ConfigResultGet> results = command.Execute();

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        // GET api/<ConfigController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfigController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConfigController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfigController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
