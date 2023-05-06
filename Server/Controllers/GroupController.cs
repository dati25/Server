using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.GroupCommands;
using Server.Results.GroupResults;
using Server.Database.Models;
using Server.Controllers.Attributes;
namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GroupController : ControllerBase
{
    private MyContext context = new MyContext();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0, bool rootGroups = false)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<GroupResultGet> results = new List<GroupResultGet>();


        context.Groups!.ToList().ForEach(x=> results.Add(new GroupResultGet(x, context)));
        if (!rootGroups)
            results = results.Where(group => !group.Name.StartsWith("pc_")).ToList();


        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Group? group = context.Groups!.Find(id);

        if (group == null)
            return NotFound(new {message = "Object not found."});

        GroupResultGet result = new GroupResultGet(group, context);

        return Ok(result);
    }
    [HttpPost]
    public IActionResult Post([FromBody] GroupCommandPost command)
    {
        if (command.Execute() == null)
            return BadRequest(new { message = "The object couldn't be created" });

        return Ok(true);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GroupCommandPut command)
    {
        if (command.Execute(id) == null)
            return BadRequest(new { message = "The object couldn't be updated" });

        return Ok(true);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        command.Delete(context.Groups!.Find(id)!);

        return Ok(true);
    }

    [HttpDelete("{idGroup}/{idPC}")]
    public IActionResult DeletePcGroups(int idGroup, int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        command.Delete(context.PcGroups!.Where(x => x.IdGroup == idGroup && x.IdPc == idPC).First()!);

        return Ok(true);
    }
}