using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.AdminCommands;
using Server.Results.AdminResults;
using Server.Database.Models;
using Server.Controllers.Attributes;
using Server.Services.QuartzService;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AdminController : ControllerBase
{
    MyContext context = new();
    ScheduleService scheduleService = new();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<Admin>? results = new List<Admin>();

        context.Admins!.ToList().ForEach(x => results.Add(x));

        results = command.Get(results, count, offset);

        if (results == null)
        {
            return NotFound(new { message = "No objects found." });
        }

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Admin? result = context.Admins!.Find(id);

        if (result == null)
            return NotFound(new { message = "Object doesn't exist." });
        
        return Ok(result);
        
    }

    [HttpPost]
    public IActionResult Post([FromBody] AdminResultPost adminPost)
    {
        AdminTestCommands testCommands = new AdminTestCommands();
        var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(adminPost.Password, workFactor: 13);

        Admin admin = new Admin(adminPost.Username, hashedPassword, adminPost.Email, null, DateTime.Now);
        var exceptions = testCommands.CheckAll(admin);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.Add(admin);
        context.SaveChanges();
        this.scheduleService.ScheduleJob(admin).GetAwaiter();
        return Ok(true);

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AdminCommandPut command)
    {
        Admin? admin = command.Execute(id, context);
        AdminTestCommands testCommands = new AdminTestCommands();

        var exceptions = testCommands.CheckAll(admin!);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        this.scheduleService.RescheduleJob(admin!).GetAwaiter();
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var admin = this.context.Admins!.Find(id);
        CommandsGetDelete command = new CommandsGetDelete();
        if (!command.Delete(admin!))
            return BadRequest(new {message = "Object doesn't exist."});
        
        this.scheduleService.UnscheduleJob(admin!).GetAwaiter();
        return Ok(true);
    }
}