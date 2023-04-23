using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Server.Database.Models;
using Server.Results.SnapshotResults;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            this.context.Snapshots!.Where(x => x.IdPC == idPC).ToList().ForEach(x => snaps.Add(new SnapshotResultGetWithId(x.IdConfig, x.Snapshot)));
            if (snaps.Count <= 0)
                return NotFound();
            return Ok(snaps);
        }

        [HttpGet("{idPC}/{idConfig}")]
        public IActionResult Get(int idPC, int idConfig)
        {
            Snapshots snapshot = this.context.Snapshots!.Where(x => x.IdPC == idPC && x.IdConfig == idConfig).ToList().First();
            if (snapshot == null)
                return NotFound();
            SnapshotResultGet result = new SnapshotResultGet(snapshot);
            return Ok(result);
        }

        [HttpPut("{idPC}/{idConfig}")]
        public IActionResult Put(int idPC, int idConfig, [FromBody] string value)
        {
            Snapshots snapshot = this.context.Snapshots!.Where(x => x.IdPC == idPC && x.IdConfig == idConfig).First();
            if (snapshot == null)
                return NotFound();
            snapshot.Snapshot = value;
            this.context.SaveChanges();
            return Ok(snapshot);
        }
    }
}
