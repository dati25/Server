using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models
{
    [Table("tbSnapshots")]
    [PrimaryKey("IdPC", "IdConfig")]
    public class Snapshots
    {
        [JsonIgnore] public int IdPC { get; set; }
        public int IdConfig { get; set; }
        public string? Snapshot { get; set; } = null;

        public Snapshots(int idPC, int IdConfig)
        {
            this.IdPC = idPC;   
            this.IdConfig = IdConfig;
        }
        public Snapshots(int idPC, int IdConfig, string Snapshot) : this(idPC, IdConfig)
        {
            this.Snapshot = Snapshot;
        }
    }
}
