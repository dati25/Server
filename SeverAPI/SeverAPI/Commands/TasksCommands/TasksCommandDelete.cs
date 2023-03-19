using SeverAPI.Database.Models;

namespace SeverAPI.Commands.TasksCommands
{
    public class TasksCommandDelete : Command
    {
        public void Execute(int id)
        {
            Tasks? task = context.Tasks.Find(id);

            if (task == null)
                return;

            context.Tasks.Remove(task);
            context.SaveChanges();
        }
    }
}
