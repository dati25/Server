using Server.Results.TaskResults;

namespace Server.Results.ComputerResults;

public class ComputerReturnPcID
{
    public string? IdPc { get; set; }

    public ComputerReturnPcID(string? idPc)
    {
        IdPc = idPc;
    }
}