using SeverAPI.Results.TaskResults;

namespace SeverAPI.Results.ComputerResults;

public class ComputerResult
{
    public int? IdPc { get; set; }
    public List<TaskResult>? Tasks { get; set; }

    public ComputerResult(int? idPc, List<TaskResult>? tasks)
    {
        IdPc = idPc;
        Tasks = tasks;
    }
}