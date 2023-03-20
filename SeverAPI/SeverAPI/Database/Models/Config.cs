using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbConfigs")]
    public class Config : IModel
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; }
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("idConfig")] public List<Source>? Sources { get; set; }
        [ForeignKey("idConfig")] public List<Destination>? Destinations { get; set; }
        [ForeignKey("idConfig")] public List<Tasks>? Tasks { get; set; }

        public Config(string Type, string? RepeatPeriod, DateTime? ExpirationDate, bool? Compress, int? Retention, int? PackageSize, int CreatedBy, bool? Status)
        {
            this.Type = Type;
            this.RepeatPeriod = RepeatPeriod;
            this.ExpirationDate = ExpirationDate;
            this.Compress = Compress;
            this.Retention = Retention;
            this.PackageSize = PackageSize;
            this.CreatedBy = CreatedBy;
            this.Status = Status;
        }
    }
}
