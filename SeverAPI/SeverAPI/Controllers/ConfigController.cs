using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.ConfigCommands;
using SeverAPI.Results.ConfigResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Controllers;

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

        context.Configs!.ToList().ForEach(x => list.Add(new ConfigResultGet(x)));

        List<ConfigResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Config? config = context.Configs!.Find(id);

        if (config == null)
            return NotFound("Object doesn't exist.");

        ConfigResultGet result = new ConfigResultGet(config);

        return Ok(result);
    }
    [HttpGet("/api/tasks/{idPC}")]
    public IActionResult GetConfigsFromPCid(int idPC)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<int> results = command.GetConfigsFromidPC(idPC);
        if (results == null)
        {
            return NotFound("No configs found.");
        }
        return Ok(results);
    }
    [HttpPost]
    public IActionResult Post([FromBody] ConfigCommandPost command)
    {
        return Ok("Task completed succesfully");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ConfigCommandPut command)
    {
        return Ok("Task completed succesfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        command.Delete(context.Configs!.Find(id)!);

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/sources/{id}")]
    public IActionResult DeleteSource(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        command.Delete(context.Sources!.Find(id)!);

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/destinations/{id}")]
    public IActionResult DeleteDestination(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        command.Delete(context.Destinations!.Find(id)!);

        return Ok("Task completed succesfully");
    }

    [HttpDelete("/api/tasks/{id}")]
    public IActionResult DeleteTask(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        command.Delete(context.Tasks!.Find(id)!);

        return Ok("Task completed succesfully");
    }
}