using SeverAPI.Results.TaskResults;

namespace SeverAPI.Results.ComputerResults;

public class ComputerResult
{
    public int? IdPc { get; set; }

    public ComputerResult(int? idPc)
    {
        IdPc = idPc;
    }
}