using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ReportCommands;
using SeverAPI.Results.ReportResults;

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int? count, int offset = 0)
        {
            ReportCommandGet command = new ReportCommandGet();
            List<ReportResultGet> results = command.Execute(count, offset);

            if (results == null)
                return BadRequest("No objects found");

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReportCommandSearchedGet command = new ReportCommandSearchedGet();
            ReportResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Searched object doesn't exist");

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
            ReportCommandDelete command = new ReportCommandDelete();

            if (command.Execute(id) == null)
                return NotFound("The object couldn't be deleted");

            return Ok("Task completed succesfully");
        }
    }
}
