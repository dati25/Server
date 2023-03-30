namespace SeverAPI.Results.PcGroupResults;

public class PCGroupResultPut
{
    public int IdPc { get; set; }

    public PCGroupResultPut(int idPc)
    {
        IdPc = idPc;
    }
}