using Server.Database.Models;

namespace Server.Results.PcGroupResults;

public class PcGroupResultGet
{
    public string IdPc { get; set; }
    public string Name { get; set; }
    public PcGroupResultGet(PcGroups pcGroup, MyContext context)
    {
        IdPc = pcGroup.IdPc;
        Computer pc = context.Computers!.Find(IdPc)!;
        Name = pc.Name;
    }
    public PcGroupResultGet(string idPc, string name)
    {
        IdPc = idPc;
        Name = name;
    }
}