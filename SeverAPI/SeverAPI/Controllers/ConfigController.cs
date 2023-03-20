using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ConfigCommands;
using SeverAPI.Results.ConfigResults;

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            ConfigCommandGet command = new ConfigCommandGet();
            List<ConfigResultGet> results = command.Execute(count, offset);

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ConfigCommandSearchedGet command = new ConfigCommandSearchedGet();
            ConfigResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Searched object doesn't exist");

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post([FromBody] ConfigCommandPost command)
        {
            if (command.Execute() == null)
                return BadRequest("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConfigCommandPut command)
        {
            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ConfigCommandDelete command = new ConfigCommandDelete();

            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}/{deletedObjectID}/{deleteType}")]
        public IActionResult DeleteSource(int id, int deletedObjectID, char deleteType)
        {
            ConfigCommandDelete command = new ConfigCommandDelete();

            switch (deleteType)
            {
                case 's':
                    if (command.DeleteSource(id, deletedObjectID) == null)
                        return BadRequest("The object couldn't be deleted");
                    break;
                case 'd':
                    if (command.DeleteDestination(id, deletedObjectID) == null)
                        return BadRequest("The object couldn't be deleted");
                    break;
                case 't':
                    if (command.DeleteTask(id, deletedObjectID) == null)
                        return BadRequest("The object couldn't be deleted");
                    break;
            }

            return Ok("Task completed succesfully");
        }
    }
}
