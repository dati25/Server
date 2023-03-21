using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.AdminsCommands;
using SeverAPI.Results.AdminResults;
using SeverAPI.Results.ConfigResults;
using SeverAPI.Database.Models;
namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        MyContext context = new MyContext();
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            CommandsGetDelete command = new CommandsGetDelete();
            List<AdminResultGet> list = new List<AdminResultGet>();

            context.Admins!.ToList().ForEach(x => list.Add(new AdminResultGet(x)));

            List<AdminResultGet> results = command.Get(list, count, offset);

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Admin? admins = context.Admins!.Find(id);

            if (admins == null)
                return NotFound("Object doesn't exist.");

            AdminResultGet result = new AdminResultGet(admins);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdminResultPost adminResult)
        {
            AdminCommandPost command = new AdminCommandPost();

            if (command.Execute(adminResult) == null)
                return BadRequest("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminCommandPut command)
        {
            if (command.Execute(id) == null)
                return BadRequest("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CommandsGetDelete command = new CommandsGetDelete();
            command.Delete(context.Admins!.Find(id));

            return Ok();
        }
    }
}
