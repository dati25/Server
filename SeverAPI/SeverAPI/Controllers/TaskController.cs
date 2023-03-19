using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.AdminsCommands;
using SeverAPI.Commands.TasksCommands;
using SeverAPI.Results.TaskResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeverAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		// GET: api/<AdminsController>
		[HttpGet]
		public IActionResult Get()
		{
			TasksCommandGet command = new TasksCommandGet();
			List<TasksResultGet> results = command.Execute();

			if (results == null)
				return NotFound("No objects found.");

			return Ok(results);
		}

		// GET api/<AdminsController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			TasksCommandSearchedGet command = new TasksCommandSearchedGet();
			TasksResultGet result = command.Execute(id);

			if (result == null)
				return NotFound("Searched object doesn't exist.");
			return Ok(result);
		}

		// POST api/<AdminsController>
		[HttpPost]
		public IActionResult Post([FromBody] TasksResultPost taskResult)
		{
			TasksCommandPost command = new TasksCommandPost();

			if (command.Execute(taskResult) == null)
				return NotFound("Searched object doesn't exist.");

			return Ok();
		}

		// PUT api/<AdminsController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] TasksCommandPut command)
		{
			command.Execute(id);
			return Ok("Task completed succesfully");
		}

		// DELETE api/<AdminsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			AdminCommandDelete command = new AdminCommandDelete();

			command.Execute(id);
		}
	}
}
