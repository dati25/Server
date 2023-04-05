using Server.Results.TaskResults;

namespace Server.Results.ComputerResults;

public class ComputerReturnPcID
{
    public int? IdPc { get; set; }

    public ComputerReturnPcID(int? idPc)
    {
        IdPc = idPc;
    }
}