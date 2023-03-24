namespace SeverAPI.Results.TaskResults
{
    public class TaskResult
    {
        public int? idConfig { get; set; }

        public TaskResult(int? idConfig)
        {
            this.idConfig = idConfig;
        }
    }
}
