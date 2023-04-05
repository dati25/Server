using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.GroupCommands;
using Server.Results.GroupResults;
using Server.Database.Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private MyContext context = new MyContext();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<GroupResultGet> list = new List<GroupResultGet>();

        context.Groups!.ToList().ForEach(x => list.Add(new GroupResultGet(x)));

        List<GroupResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Group? group = context.Groups!.Find(id);

        if (group == null)
            return NotFound("Object doesn't exist.");

        GroupResultGet result = new GroupResultGet(group);

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
        CommandsGetDelete command = new CommandsGetDelete();
        command.Delete(context.Groups!.Find(id)!);

        return Ok("Task completed succesfully");
    }

    [HttpDelete("{idGroup}/{idPC}")]
    public IActionResult DeletePcGroups(int idGroup, int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        command.Delete(context.PcGroups!.Where(x => x.IdGroup == idGroup && x.IdPc == idPC).First()!);

        return Ok("Task completed succesfully");
    }
}