using SeverAPI.Database.Models;

namespace SeverAPI.Results.PcGroupResults;

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