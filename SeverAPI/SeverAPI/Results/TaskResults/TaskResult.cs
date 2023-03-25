namespace SeverAPI.Results.TaskResults;

public class TaskResult
{
    public int? IdConfig { get; set; }

    public TaskResult(int? idConfig)
    {
        IdConfig = idConfig;
    }
}