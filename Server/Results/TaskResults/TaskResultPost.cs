namespace Server.Results.TaskResults;

public class TaskResultPost
{
    public int IdGroup { get; set; }
    public TaskResultPost(int IdGroup)
    {
        this.IdGroup = IdGroup;
    }
}