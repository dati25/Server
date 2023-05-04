using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ConfigCommands;
using Server.Results.ConfigResults;
using Server.Database.Models;
using Server.Results.TaskResults;
using Microsoft.AspNetCore.Authorization;

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
    [AllowAnonymous]
    public IActionResult GetConfigsFromPCid(int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<int> results = command.GetConfigsFromidPC(idPC);
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

    [HttpDelete("/api/{idConfig}/{idGroup}")]
    [Authorize]
    public IActionResult DeleteTask(int idConfig, int idObject, bool isGroup)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (isGroup)
        {
            command.Delete(this.context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdGroup == idObject).First()!);
        }
        else
        {
            Computer? pc = this.context.Computers!.Find(idObject);
            if (pc != null)
                return NotFound();

            Group? group = this.context.Groups!.Find("pc_" + pc!.Name);
            if (pc != null)
                return NotFound();

            command.Delete(this.context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdGroup == group!.Id).First()!);
        }
        return Ok(true);
    }
}