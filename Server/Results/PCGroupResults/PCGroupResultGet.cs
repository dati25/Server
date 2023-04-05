using Server.Database.Models;

namespace Server.Results.PcGroupResults;

public class PcGroupResultGet
{
    public int IdPc { get; set; }

    public PcGroupResultGet(PcGroups pcGroup)
    {
        IdPc = pcGroup.IdPc;
    }
    public PcGroupResultGet(int idPc)
    {
        IdPc = idPc;
    }
}