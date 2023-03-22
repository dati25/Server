using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands;
using SeverAPI.Commands.ReportCommands;
using SeverAPI.Results.ReportResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Controllers
{
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

            if (results == null)
                return NotFound("No objects found");

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
            ReportCommandPost command = new ReportCommandPost();

            if (command.Execute(reportResult) == null)
                return NotFound("The object couldn't be created");

            return Ok("Task completed succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReportCommandPut command)
        {
            if (command.Execute(id) == null)
                return NotFound("The object couldn't be updated");

            return Ok("Task completed succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CommandsGetDelete command = new CommandsGetDelete();
            command.Delete(context.Reports!.Find(id)!);

            return Ok();
        }
    }
}
