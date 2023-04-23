using Server.Database.Models;

namespace Server.Results.SnapshotResults
{
    public class SnapshotResultGet
    {
       public string? Snapshot { get; set; }
        public SnapshotResultGet(Snapshots snapshot)
        {
            this.Snapshot = snapshot.Snapshot;
        }
    }
}
