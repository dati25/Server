namespace SeverAPI.Results.TaskResults
{
    public class TaskResultGet
    {
        public int id { get; set; }
        public int idPC { get; set; }

        public TaskResultGet(Database.Models.Tasks task)
        {
            id = task.id;
            this.idPC = task.idPC;
        }

    }
}
