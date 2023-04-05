namespace Server.Results.TaskResults;

public class TaskResultPut
{
    public string? Snapshot { get; set; }
    public TaskResultPut(string? snapshot)
    {
        Snapshot = snapshot;
    }
}