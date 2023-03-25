using SeverAPI.Database.Models;

namespace SeverAPI.Results.PcGroupResults;

public class PcGroupResultGet
{
    public int Id { get; set; }
    public int IdPc { get; set; }

    public PcGroupResultGet(PcGroups pcGroup)
    {
        Id = pcGroup.Id;
        IdPc = pcGroup.IdPc;
    }
}