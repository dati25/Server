namespace SeverAPI.Results.TaskResults;

public class TaskResultPost
{
    public int IdPc { get; set; }
    public TaskResultPost(int IdPc)
    {
        this.IdPc = IdPc;
    }
}