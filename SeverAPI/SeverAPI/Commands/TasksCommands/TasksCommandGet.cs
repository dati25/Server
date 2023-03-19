using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.TasksCommands
{
    public class TasksCommandGet : Command
    {
        public List<TasksResultGet> Execute()
        {
            List<TasksResultGet>? ResultTasks = new List<TasksResultGet>();
            context.Tasks.ToList().ForEach(x => ResultTasks.Add(new TasksResultGet(x)));

            return ResultTasks!;
        }
    }
}
