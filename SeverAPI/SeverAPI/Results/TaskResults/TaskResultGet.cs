using SeverAPI.Database.Models;

namespace SeverAPI.Results.TaskResults
{
    public class TaskResultGet
    {
        public int id { get; set; }
        public int idPC { get; set; }

        public TaskResultGet(Tasks task)
        {
            id = task.Id;
            this.idPC = task.IdPc;
        }
    }
}
