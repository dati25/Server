using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models
{
    [Table("tbConfigs")]
    public class Config : IModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; } // Null = once
        public DateTime? ExpirationDate { get; set; } // Null = never
        public bool? Compress { get; set; } // Default false
        public int? Retention { get; set; } // null = unlimitied
        public int? PackageSize { get; set; } // null = unlimited
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }  //Default false (turned off)
        [ForeignKey("IdConfig")] public List<Source>? Sources { get; set; }
        [ForeignKey("IdConfig")] public List<Destination>? Destinations { get; set; }
        [ForeignKey("IdConfig")] public List<Tasks>? Tasks { get; set; }

        public Config(string type, string? repeatPeriod, DateTime? expirationDate, bool? compress, int? retention, int? packageSize, int createdBy, bool? status)
        {
            Type = type;
            RepeatPeriod = repeatPeriod;
            ExpirationDate = expirationDate;
            Compress = compress ?? false;
            Retention = retention;
            PackageSize = packageSize;
            CreatedBy = createdBy;
            Status = status ?? false;
        }
    }
}
