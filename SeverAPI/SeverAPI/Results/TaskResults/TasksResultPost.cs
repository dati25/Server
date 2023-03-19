using SeverAPI.Database.Models;

namespace SeverAPI.Results.TaskResults
{
    public class TasksResultPost : IModel
    {
        public int idPC { get; set; }
        public int idConfig { get; set; }
        public bool? Status { get; set; }

        public TasksResultPost(int idPC, int idConfig, bool? Status)
        {
            this.idPC = idPC;
            this.idConfig = idConfig;
            this.Status = Status;
        }
    }
}
