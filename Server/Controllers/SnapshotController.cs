using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Server.Database.Models;
using Server.Results.SnapshotResults;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnapshotController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet("api/Snapshots/{idPC}")]
        public IActionResult GetFromPCID(int idPC)
        {
            List<SnapshotResultGetWithId> snaps = new List<SnapshotResultGetWithId>();
            this.context.Snapshots!.Where(x => x.ComputerId == idPC).ToList().ForEach(x => snaps.Add(new SnapshotResultGetWithId(x.IdConfig, x.Snapshot)));
            if (snaps.Count <= 0)
                return NotFound(new { message = "Object doesn't exist" });
            return Ok(snaps);
        }

        [HttpPut("{idPC}/{idConfig}")]
        public IActionResult Put(int idPC, int idConfig, [FromBody] string value)
        {
            Snapshots snapshot = this.context.Snapshots!.Where(x => x.ComputerId == idPC && x.IdConfig == idConfig).First();
            if (snapshot == null)
                return NotFound(new {message = "Object doesn't exist"});
            snapshot.Snapshot = value;
            this.context.SaveChanges();
            return Ok(snapshot);
        }
    }
}
