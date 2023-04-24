using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ComputerCommands;
using Server.Results.ComputerResults;
using Server.Database.Models;
using Microsoft.AspNetCore.Routing.Template;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputerController : ControllerBase
{
    MyContext context = new MyContext();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<Computer> results = new List<Computer>();

        context.Computers!.ToList().ForEach(x => results.Add(x));

        results = command.Get(results, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Computer? result = context.Computers!.Find(id);

        if (result == null)
            return NotFound(new { message = "Object doesn't exist." });

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ComputerResultPost computerResult)
    {
        ComputerTestCommands testCommands = new ComputerTestCommands();
        Computer pc = new(computerResult.MacAddress, computerResult.IpAddress, computerResult.Name, computerResult.Status);

        var exceptions = testCommands.CheckAll(pc);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.Add(pc);
        context.SaveChanges();

        return Ok(pc.Id);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ComputerCommandPut command)
    {
        Computer? pc = command.Execute(id);
        ComputerTestCommands testCommands = new ComputerTestCommands();

        var exceptions = testCommands.CheckAll(pc!);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        if (!command.Delete(this.context.Computers!.Find(id)!))
            return BadRequest(new { message = "Object doesn't exist" });

        return Ok(true);
    }
    //[HttpGet("{idPC}/{idConfig}")]
    //public IActionResult GetSnapshot(int idPC, int idConfig)
    //{
        
    //}
}