using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ConfigCommands;
using SeverAPI.Results.ConfigResults;
using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;

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
        public IActionResult Get(int id)
        {
            ConfigCommandSearchedGet command = new ConfigCommandSearchedGet();
            ConfigResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Object not found.");

            return Ok(result);

        }

        // POST api/<ConfigController>
        [HttpPost]
        public IActionResult Post([FromBody] ConfigCommandPost command)
        {

            command.Execute();

            return Ok();
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
