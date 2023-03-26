using SeverAPI.Results.TaskResults;

namespace SeverAPI.Results.ComputerResults;

public class ComputerReturnPcID
{
    public int? IdPc { get; set; }

    public ComputerReturnPcID(int? idPc)
    {
        IdPc = idPc;
    }
}