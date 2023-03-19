namespace SeverAPI.Results.TaskResults
{
    public class TaskResultGet
    {
        public int idPC { get; set; }

        public TaskResultGet(Database.Models.Task task)
        {
            this.idPC = task.idPC;
        }

    }
}
