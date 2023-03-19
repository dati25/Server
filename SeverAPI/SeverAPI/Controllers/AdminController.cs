using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.AdminsCommands;
using SeverAPI.Results.AdminResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/<AdminsController>
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            AdminCommandGet command = new AdminCommandGet();
            List<AdminResultGet> results = command.Execute(count, offset);

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        // GET api/<AdminsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            AdminCommandSearchedGet command = new AdminCommandSearchedGet();
            AdminResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Searched object doesn't exist");

            return Ok(result);
        }

        // POST api/<AdminsController>
        [HttpPost]
        public IActionResult Post([FromBody] AdminResultPost adminResult)
        {
            AdminCommandPost command = new AdminCommandPost();

            if (command.Execute(adminResult) == null)
                return NotFound("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        // PUT api/<AdminsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminCommandPut command)
        {
            if (command.Execute(id) == null)
                return NotFound("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        // DELETE api/<AdminsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdminCommandDelete command = new AdminCommandDelete();

            if (command.Execute(id) == null)
                return NotFound("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }
    }
}
