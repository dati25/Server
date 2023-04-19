using Server.Database.Models;
using Server.Results.SnapshotResults;

namespace Server.Results.ComputerResults
{
    public class ComputerResultGet
    {

        public int Id { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public char Status { get; set; }
        public List<SnapshotResultGet>? Snapshots { get; set; } = new List<SnapshotResultGet>();
        public ComputerResultGet(int id, string macAddress, string ipAddress, string name, char status, MyContext context)
        {
            Id = id;
            MacAddress = macAddress;
            IpAddress = ipAddress;
            Name = name;
            Status = status;
            context.Snapshots!.Where(x => x.IdPC == this.Id).ToList().ForEach(x => this.Snapshots!.Add(new SnapshotResultGet(x)));
        }
    }
}
