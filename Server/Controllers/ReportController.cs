using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ReportCommands;
using Server.Results.ReportResults;
using Server.Database.Models;
using Server.Commands.ComputerCommands;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private MyContext context = new MyContext();
    [HttpGet]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<ReportResultGet> list = new List<ReportResultGet>();

        context.Reports!.ToList().ForEach(x => list.Add(new ReportResultGet(x)));

        List<ReportResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Report? report = context.Reports!.Find(id);

        if (report == null)
            return NotFound("Object doesn't exist.");

        ReportResultGet result = new ReportResultGet(report);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ReportResultPost reportResult)
    {
        ReportTestCommands testCommands = new ReportTestCommands();
        Report? report = new Report(reportResult.IdPc, reportResult.Status, DateTime.Now, reportResult.Description);
        var exceptions = testCommands.CheckAll(report);

        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        this.context.Add(report);
        this.context.SaveChanges();
        return Ok("Task completed succesfully");
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ReportCommandPut command)
    {
        Report? report = command.Execute(id);
        ReportTestCommands testCommands = new ReportTestCommands();

        var exceptions = testCommands.CheckAll(report!);
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok("Task completed succesfully");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        if (!command.Delete(this.context.Reports!.Find(id)!))
            return BadRequest("Object doesn't exist");

        return Ok("Task completed succesfully");
    }
}