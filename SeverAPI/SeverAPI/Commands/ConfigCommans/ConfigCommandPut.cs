using SeverAPI.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Commands.ConfigCommans
{
    public class ConfigCommandPut : Command
    {
        public string? Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; }
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int? CreatedBy { get; set; }
        public bool? Status { get; set; }
        public List<Source>? Sources { get; set; }

        public Config Execute(int id)
        {
            Config config = context.Configs.Find(id);
            if (config == null)
                return null;

            config.Type = Type ?? config.Type;
            config.RepeatPeriod = RepeatPeriod ?? config.RepeatPeriod;
            config.ExpirationDate = ExpirationDate ?? config.ExpirationDate;
            config.Compress = Compress ?? config.Compress;
            config.Retention = Retention ?? config.Retention;
            config.PackageSize = PackageSize ?? config.PackageSize;
            config.CreatedBy = CreatedBy ?? config.CreatedBy;
            config.Status = Status ?? config.Status;
            config.Sources = Sources ?? config.Sources;

            context.SaveChanges();

            return config;
        }



    }
}
