using Microsoft.AspNetCore.Mvc;
using Server.Commands;
using Server.Commands.ReportCommands;
using Server.Results.ReportResults;
using Server.Database.Models;
using Server.Commands.ComputerCommands;
using Server.Controllers.Attributes;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private MyContext context = new MyContext();
    [HttpGet]
    [Authorize]
    public IActionResult Get(int? count, int offset = 0)
    {
        CommandsGetDelete command = new CommandsGetDelete();
        List<ReportResultGet> list = new List<ReportResultGet>();

        context.Reports!.ToList().ForEach(x => list.Add(new ReportResultGet(x)));

        List<ReportResultGet> results = command.Get(list, count, offset);

        return Ok(results);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(int id)
    {
        Report? report = context.Reports!.Find(id);

        if (report == null)
            return NotFound(new { message = "Object doesn't exist." });

        ReportResultGet result = new ReportResultGet(report);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ReportResultPost reportResult)
    {
        Report? report = new Report(reportResult.IdPc, reportResult.IdConfig, reportResult.Status, reportResult.ReportTime, reportResult.Description);
        ReportTestCommands testCommands = new ReportTestCommands(report);
        var exceptions = testCommands.CheckAll();

        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        this.context.Add(report);
        this.context.SaveChanges();
        return Ok(true);
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put(int id, [FromBody] ReportCommandPut command)
    {
        Report? report = command.Execute(id);
        ReportTestCommands testCommands = new ReportTestCommands(report);

        var exceptions = testCommands.CheckAll();
        if (exceptions.Count > 0)
            return BadRequest(exceptions);

        context.SaveChanges();
        return Ok(true);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        CommandsGetDelete command = new CommandsGetDelete();

        if (!command.Delete(this.context.Reports!.Find(id)!))
            return BadRequest(new { message = "Object doesn't exist" });

        return Ok(true);
    }
}