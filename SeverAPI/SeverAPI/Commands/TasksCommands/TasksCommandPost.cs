using SeverAPI.Database.Models;
using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.TasksCommands
{
    public class TasksCommandPost: Command
    {
        public TasksResultPost Execute(TasksResultPost task)
        {
            this.context.Add(new Tasks(task.idPC, task.idConfig, task.Status));
            this.context.SaveChanges();

            return task;
        }
        
    }
}
