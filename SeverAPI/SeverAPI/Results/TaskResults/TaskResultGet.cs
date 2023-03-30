using SeverAPI.Database.Models;

namespace SeverAPI.Results.TaskResults
{
    public class TaskResultGet
    {
        public int Id { get; set; }
        public int IdPC { get; set; }
        public string? Snapshot { get; set; }
        public TaskResultGet(Tasks task)
        {
            Id = task.Id;
            IdPC = task.IdPc;
            Snapshot = task.Snapshot;
        }
    }
}
