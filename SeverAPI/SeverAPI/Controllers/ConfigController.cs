using Microsoft.AspNetCore.Mvc;
using SeverAPI.Commands.ConfigCommands;
using SeverAPI.Results.ConfigResults;
using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        // GET: api/<ConfigController>
        [HttpGet]
        public IActionResult Get()
        {
            ConfigCommandGet command = new ConfigCommandGet();
            List<ConfigResultGet> results = command.Execute();

            if (results == null)
                return NotFound("No objects found");

            return Ok(results);
        }

        // GET api/<ConfigController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ConfigCommandSearchedGet command = new ConfigCommandSearchedGet();
            ConfigResultGet result = command.Execute(id);

            if (result == null)
                return NotFound("Object not found.");

            return Ok(result);

        }

        // POST api/<ConfigController>
        [HttpPost]
        public IActionResult Post([FromBody] ConfigCommandPost command)
        {
            if (command.Execute() == null)
                return BadRequest();
            return Ok();
        }

        // PUT api/<ConfigController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ConfigCommandPut command)
        {
            command.Execute(id);

        }

        // DELETE api/<ConfigController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             ConfigCommandDelete command = new ConfigCommandDelete();

            command.Execute(id);
        }
        [HttpDelete("{id}/{deletedObjectID}/{deleteType}")]
        public void DeleteSource(int id, int deletedObjectID, char deleteType)
        {
            ConfigCommandDelete command = new ConfigCommandDelete();

            switch (deleteType)
            {
                case 's':
                    command.DeleteSource(id, deletedObjectID);
                    break;
                case 'd':
                    command.DeleteDestination(id, deletedObjectID);
                    break;
                    case 't':
                    command.DeleteTask(id, deletedObjectID);
                    break;
            }
        }
        //[HttpDelete("{id}/{destinationId}")]
        //public void DeleteDestination(int id, int destinationId)
        //{
        //    ConfigCommandDelete command = new ConfigCommandDelete();

        //    command.DeleteDestination(id, destinationId);
        //}
        //[HttpDelete("{id}/{taskId}")]
        //public void DeleteTask(int id, int taskId)
        //{
        //    ConfigCommandDelete command = new ConfigCommandDelete();

        //    command.DeleteTask(id, taskId);
        //}
    }
}
