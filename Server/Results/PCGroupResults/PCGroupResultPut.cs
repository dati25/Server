namespace Server.Results.PcGroupResults;

public class PCGroupResultPut
{
    public string IdPc { get; set; }

    public PCGroupResultPut(string idPc)
    {
        IdPc = idPc;
    }
}