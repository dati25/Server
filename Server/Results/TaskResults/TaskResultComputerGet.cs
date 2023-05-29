using Org.BouncyCastle.Asn1.Mozilla;
using Server.Results.GroupResults;
using Server.Results.ComputerResults;
using Server.Results.PcGroupResults;
using Server.Database.Models;
namespace Server.Results.TaskResults
{
    public class TaskResultComputerGet
    {
        public string Name { get; set; }
        public string IdPc { get; set; }
        public TaskResultComputerGet(Group group, MyContext context)
        {
            Computer pc = context.Computers!.Where(x => x.Name == group.Name.Substring(3)).First();
            this.Name = pc.Name;
            this.IdPc = pc.Id;
        }



    }
}
