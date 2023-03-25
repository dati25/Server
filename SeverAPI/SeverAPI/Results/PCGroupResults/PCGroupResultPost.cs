namespace SeverAPI.Results.PcGroupResults;

public class PcGroupResultPost
{
    public int IdPc { get; set; }

    public PcGroupResultPost(int idPc)
    {
        IdPc = idPc;
    }
}