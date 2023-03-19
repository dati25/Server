using SeverAPI.Database.Models;

namespace SeverAPI.Commands.TasksCommands
{
    public class TasksCommandPut : Command
    {
        public int? idPC { get; set; }
        public int? idConfig { get; set; }
        public bool? Status { get; set; }

        public TasksCommandPut(int? idPC, int? idConfig, bool? status)
        {
            this.idPC = idPC;
            this.idConfig = idConfig;
            this.Status = status;
        }
        public Tasks Execute(int id)
        {
            Tasks? task = context.Tasks.Find(id);

            if (task == null)
                return null!;

            task.idPC = idPC ?? task.idPC;
            task.idConfig = idConfig ?? task.idConfig;
            task.Status = Status ?? task.Status;

            context.SaveChanges();

            return task;
        }
    }
}
