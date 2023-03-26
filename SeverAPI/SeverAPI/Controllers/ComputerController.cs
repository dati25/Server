using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.ComputerCommands;
using SeverAPI.Results.ComputerResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Controllers;

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
            return NotFound("Object doesn't exist.");

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ComputerResultPost computerResult)
    {
        ComputerCommandPost command = new ComputerCommandPost();

        int? result = await command.Execute(computerResult);

        if (result == null)
            return BadRequest("The object couldn't be created");

        return Ok(new ComputerReturnPcID(result));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ComputerCommandPut command)
    {
        if (command.Execute(id) == null)
            return BadRequest("The object couldn't be updated");

        return Ok("Task completed succesfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        command.Delete(context.Computers!.Find(id)!);

        return Ok("Task completed succesfully");
    }
}