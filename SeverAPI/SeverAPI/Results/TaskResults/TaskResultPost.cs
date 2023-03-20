namespace SeverAPI.Results.TaskResults
{
    public class TaskResultPost
    {
        public int idPC { get; set; }

        public TaskResultPost(int idPC)
        {
            this.idPC = idPC;
        }
    }
}
