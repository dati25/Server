using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ComputerCommands;
using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            ComputerCommandGet command = new ComputerCommandGet();
            List<ComputerResultGet> results = command.Execute(count, offset);

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ComputerCommandSearchedGet command = new ComputerCommandSearchedGet();
            ComputerResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Searched object doesn't exist");

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ComputerResultPost computerResult)
        {
            ComputerCommandPost command = new ComputerCommandPost();

            if (command.Execute(computerResult) == null)
                return BadRequest("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ComputerCommandPut command)
        {
            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ComputerCommandDelete command = new ComputerCommandDelete();

            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }
    }
}
