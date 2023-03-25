﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbConfigs")]
    public class Config : IModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; }
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("IdConfig")] public List<Source>? Sources { get; set; }
        [ForeignKey("IdConfig")] public List<Destination>? Destinations { get; set; }
        [ForeignKey("IdConfig")] public List<Tasks>? Tasks { get; set; }

        public Config(string type, string? repeatPeriod, DateTime? expirationDate, bool? compress, int? retention, int? packageSize, int createdBy, bool? status)
        {
            Type = type;
            RepeatPeriod = repeatPeriod;
            ExpirationDate = expirationDate;
            Compress = compress;
            Retention = retention;
            PackageSize = packageSize;
            CreatedBy = createdBy;
            Status = status;
        }
    }
}
