using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.AdminCommands;
using SeverAPI.Results.AdminResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    MyContext context = new MyContext();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<Admin> results = new List<Admin>();

        context.Admins!.ToList().ForEach(x => results.Add(x));

        results = command.Get(results, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Admin? result = context.Admins!.Find(id);

        if (result == null)
            return NotFound("Object doesn't exist.");

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AdminResultPost adminResult)
    {
        AdminCommandPost? command = new AdminCommandPost();

        if (command.Execute(adminResult) == null)
            return BadRequest("The object couldn't be created");

        return Ok("Task completed succesfully");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AdminCommandPut command)
    {
        if (command.Execute(id) == null)
            return BadRequest("The object couldn't be updated");

        return Ok("Task completed succesfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        command.Delete(context.Admins!.Find(id)!);

        return Ok("Task completed succesfully");
    }
}