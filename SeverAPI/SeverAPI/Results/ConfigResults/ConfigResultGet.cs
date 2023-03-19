using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Results.ConfigResults
{
    public class ConfigResultGet
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string RepeatPeriod { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Compress { get; set; }
        public int Retention { get; set; }
        public int PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
        [ForeignKey("idConfig")] public List<SourceResultGet> Sources { get; set; } = new List<SourceResultGet>();
        MyContext context = new MyContext();


        public ConfigResultGet(Config config)
        {
            this.id = config.id;
            this.Type = config.Type;
            this.RepeatPeriod = config.RepeatPeriod;
            this.ExpirationDate = config.ExpirationDate;
            this.Compress = config.Compress;
            this.Retention = config.Retention;
            this.PackageSize = config.PackageSize;
            this.CreatedBy = config.CreatedBy;
            this.Status = config.Status;
            context.Sources.Where(x => x.idConfig == config.id).ToList().ForEach(x => this.Sources.Add(new SourceResultGet(x)));
        }

    }
}
