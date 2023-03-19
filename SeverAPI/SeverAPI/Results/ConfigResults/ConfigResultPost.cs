using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Results.ConfigResults
{
    public class ConfigResultPost
    {
        public string Type { get; set; }
        public string RepeatPeriod { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Compress { get; set; }
        public int Retention { get; set; }
        public int PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
        public List<SourceResultGet> Sources { get; set; }


        public ConfigResultPost(string Type, string RepeatPeriod, DateTime ExpirationDate, bool Compress, int Retention, int PackageSize, int CreatedBy, bool Status, List<SourceResultGet> sources)
        {
            this.Type = Type;
            this.RepeatPeriod = RepeatPeriod;
            this.ExpirationDate = ExpirationDate;
            this.Compress = Compress;
            this.Retention = Retention;
            this.PackageSize = PackageSize;
            this.CreatedBy = CreatedBy;
            this.Status = Status;
            this.Sources = sources;
        }


    }
}
