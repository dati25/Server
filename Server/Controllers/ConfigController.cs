using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ConfigCommands;
using Server.Results.ConfigResults;
using Server.Database.Models;
using Server.Results.TaskResults;

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
            return NotFound("Object doesn't exist.");

        ConfigResultGet result = new ConfigResultGet(config,context);

        return Ok(result);
    }

    [HttpGet("/api/tasks/{idPC}")]
    public IActionResult GetConfigsFromPCid(int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<int> results = command.GetConfigsFromidPC(idPC);
        if (results == null)
            return NotFound("No configs found.");

        return Ok(results);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ConfigCommandPost command)
    {
        ConfigTestCommands testCommands = new ConfigTestCommands();

        var exceptions = testCommands.CheckConfig(command);

        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        command.Execute();
        return Ok("Task completed succesfully.");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ConfigCommandPut command)
    {
        Config config = command.Execute(id, context);
        ConfigTestCommands testCommands = new ConfigTestCommands();

        var exceptions = testCommands.CheckConfig(config, id);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok("Task completed succesfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Configs!.Find(id)!))
            return BadRequest("Object doesn't exist");

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/sources/{id}")]
    public IActionResult DeleteSource(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Sources!.Find(id)!))
            return BadRequest("Object doesn't exist");

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/destinations/{id}")]
    public IActionResult DeleteDestination(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Destinations!.Find(id)!))
            return BadRequest("Object doesn't exist");

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/{idConfig}/{idGroup}")]
    public IActionResult DeleteTask(int idConfig, int idGroup)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        //command.Delete(context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdPc == idPC).First()!);
        command.Delete(this.context.Tasks!.Where(x => x.IdConfig == idConfig && x.IdGroup == idGroup).First()!);
        return Ok("Task completed succesfully");
    }
}