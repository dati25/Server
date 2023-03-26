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
    public IActionResult Post([FromBody] ComputerResultPost computerResult)
    {
        ComputerCommandPost command = new ComputerCommandPost();
        try
        {
            int result = command.Execute(computerResult).Id;
            return Ok(new ComputerReturnPcID(result));
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ComputerCommandPut command)
    {
        try
        {
            command.Execute(id);
            return Ok("Task completed succesfully");
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        try
        {
            command.Delete(context.Computers!.Find(id)!);
            return Ok("Task completed succesfully");
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}