namespace Server.Results.SnapshotResults
{
    public class SnapshotResultGet
    {
       public string? Snapshot { get; set; }
        public SnapshotResultGet(string? snapshot)
        {
            this.Snapshot = snapshot;
        }
    }
}
