using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.GroupCommands;
using SeverAPI.Results.GroupResults;

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            GroupCommandGet command = new GroupCommandGet();
            List<GroupResultGet> results = command.Execute(count, offset);

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            GroupCommandSearchedGet command = new GroupCommandSearchedGet();
            GroupResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Object not found.");

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post([FromBody] GroupCommandPost command)
        {
            if (command.Execute() == null)
                return BadRequest("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GroupCommandPut command)
        {
            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GroupCommandDelete command = new GroupCommandDelete();

            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}/{pcGroupID}")]
        public IActionResult DeletePCGroups(int id, int pcGroupID)
        {
            GroupCommandDelete command = new GroupCommandDelete();

            if (command.DeletePCGroups(id, pcGroupID) == null)
                return BadRequest("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }
    }
}
