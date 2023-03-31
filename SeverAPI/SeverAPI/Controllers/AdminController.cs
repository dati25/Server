using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.AdminCommands;
using SeverAPI.Results.AdminResults;
using SeverAPI.Database.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SeverAPI.Commands.TestingCommands;

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
        List<Admin>? results = new List<Admin>();

        context.Admins!.ToList().ForEach(x => results.Add(x));

        results = command.Get(results, count, offset);

        if (results == null)
        {
            return NotFound("No objects found.");
        }

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Admin? result = context.Admins!.Find(id);

        if (result == null)
            return NotFound("Object doesn't exist.");
        string s = "Hello, \nhello";
        s = JsonConvert.SerializeObject(s);
        return Ok(s);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AdminResultPost adminPost)
    {
        AdminTestCommands testCommands = new AdminTestCommands();
        Admin admin = new Admin(adminPost.Username, adminPost.Password, adminPost.Email, null);

        var exceptions = testCommands.CheckAll(admin);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.Add(admin);
        context.SaveChanges();
        return Ok("Task completed succesfully");

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AdminCommandPut command)
    {
        Admin? admin = command.Execute(id);
        AdminTestCommands testCommands = new AdminTestCommands();

        var exceptions = testCommands.CheckAll(admin!);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok("Task completed succesfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(this.context.Admins!.Find(id)!))
            return BadRequest("Object doesn't exist");

        return Ok("Task completed succesfully");
    }
}