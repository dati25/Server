using SeverAPI.Database.Models;

namespace SeverAPI.Results.TaskResults
{
    public class TasksResultGet
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public int idConfig { get; set; }
        public bool? Status { get; set; }
        public TasksResultGet(Tasks task)
        {
            this.id = task.id;
            this.idPC = task.idPC;
            this.idConfig = task.idConfig;
            this.Status = task.Status;
        }
    }
}
