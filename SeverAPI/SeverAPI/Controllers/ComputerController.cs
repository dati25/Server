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
        List<ComputerResultGet> list = new List<ComputerResultGet>();

        context.Computers!.ToList().ForEach(x => list.Add(new ComputerResultGet(x)));

        List<ComputerResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Computer? pc = context.Computers!.Find(id);

        if (pc == null)
            return NotFound("Object doesn't exist.");

        ComputerResultGet result = new ComputerResultGet(pc);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ComputerResultPost computerResult)
    {
        ComputerCommandPost command = new ComputerCommandPost();

        int? result = await command.Execute(computerResult);

        if (result == null)
            return BadRequest("The object couldn't be created");

        return Ok(new ComputerResult(result));
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