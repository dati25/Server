namespace Server.Results.SnapshotResults
{
    public class SnapshotResultGetWithId
    {
        public int Id { get; set; }
        public string? Snapshot { get; set; }
        public SnapshotResultGetWithId(int Id, string? snapshot)
        {
            this.Id = Id;
            this.Snapshot = snapshot;
        }


    }
}
