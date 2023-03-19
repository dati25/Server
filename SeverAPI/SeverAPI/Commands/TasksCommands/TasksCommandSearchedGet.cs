using SeverAPI.Database.Models;
using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.TasksCommands
{
    public class TasksCommandSearchedGet : Command
    {
        public TasksResultGet Execute(int id)
        {
            Tasks? task = context.Tasks.Find(id);

            if (task == null)
                return null!;

            return new TasksResultGet(task);
        }
    }
}
