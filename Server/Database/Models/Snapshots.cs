using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models
{
    [Table("tbSnapshots")]
    [PrimaryKey("ComputerId", "IdConfig")]
    public class Snapshots
    {
        [JsonIgnore] public string ComputerId { get; set; }
        public int IdConfig { get; set; }
        public string? Snapshot { get; set; } = null;

        public Snapshots(string ComputerId, int IdConfig)
        {
            this.ComputerId = ComputerId;   
            this.IdConfig = IdConfig;
        }
        public Snapshots(string idPC, int IdConfig, string Snapshot) : this(idPC, IdConfig)
        {
            this.Snapshot = Snapshot;
        }
    }
}
