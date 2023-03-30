using SeverAPI.Database.Models;

namespace SeverAPI.Results.TaskResults
{
    public class TaskResultGet
    {
        public int IdPC { get; set; }
        public string? Snapshot { get; set; }
        public TaskResultGet(Tasks task)
        {
            IdPC = task.IdPc;
            Snapshot = task.Snapshot;
        }
    }
}
