using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ConfigCommands;
using Server.Results.ConfigResults;
using Server.Database.Models;
using Server.Controllers.Attributes;
using System.Reflection;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfigController : ControllerBase
{
    private MyContext context = new MyContext();

    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<ConfigResultGet> list = new List<ConfigResultGet>();

        context.Configs!.ToList().ForEach(x => list.Add(new ConfigResultGet(x, context)));
        List<ConfigResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Config? config = context.Configs!.Find(id);

        if (config == null)
            return NotFound(new { message = "Object doesn't exist." });

        ConfigResultGet result = new ConfigResultGet(config, context);

        return Ok(result);
    }

    [HttpGet("/api/tasks/{idPC}")]
    public IActionResult GetConfigsFromPCid(int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        var pc = this.context.Computers!.Find(idPC);

        if (pc == null)
            return NotFound(new { message = "PC doesn't exist." });

        List<int> results = command.GetConfigsFromidPC(pc);
        if (results == null)
            return NotFound(new { message = "No configs found." });

        return Ok(results);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] ConfigCommandPost command)
    {
        ConfigTestCommands testCommands = new ConfigTestCommands();

        var exceptions = testCommands.CheckConfig(command, context);

        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        command.Execute(context);
        context.SaveChanges();
        return Ok(true);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put(int id, [FromBody] ConfigCommandPut command)
    {
        Config config = command.Execute(id, context);
        ConfigTestCommands testCommands = new ConfigTestCommands();

        var exceptions = testCommands.CheckConfig(config, context, id);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok(true);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Configs!.Find(id)!))
            return BadRequest(new { message = "Object doesn't exist" });

        return Ok(true);
    }

    [HttpDelete("/api/sources/{id}")]
    [Authorize]
    public IActionResult DeleteSource(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Sources!.Find(id)!))
            return BadRequest(new { message = "Object doesn't exist" });

        return Ok(true);
    }

    [HttpDelete("/api/destinations/{id}")]
    [Authorize]
    public IActionResult DeleteDestination(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Destinations!.Find(id)!))
            return BadRequest(new { message = "Object doesn't exist" });

        return Ok(true);
    }

    [HttpDelete("/api/{idConfig}/{idGroup}/{isGroup}")]
    [Authorize]
    public IActionResult DeleteTask(int idConfig, int idGroup, char isGroup)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (isGroup == 't')
        {
            command.Delete(this.context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdGroup == idGroup).First()!);
        }
        else if (isGroup == 'f')
        {
            Computer? pc = this.context.Computers!.Find(idGroup);
            if (pc == null)
                return NotFound();

            Group? group = this.context.Groups!.Where(x => x.Name == "pc_" + pc!.Name).First();
            if (pc == null)
                return NotFound();

            command.Delete(this.context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdGroup == group!.Id).First()!);
        }
        else
        {
            return BadRequest(new { message = "Invalid input." });
        }
        return Ok(true);
    }
}