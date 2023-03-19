using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using SeverAPI.Results.ConfigResults;
namespace SeverAPI.Commands.ConfigCommans
{
    public class ConfigCommandPost : Command
    {
        public ConfigCommandPost(string type, string repeatPeriod, DateTime expirationDate, bool compress, int retention, int packageSize, int createdBy, bool status, List<SourceResultGet> sources)
        {
            Type = type;
            RepeatPeriod = repeatPeriod;
            ExpirationDate = expirationDate;
            Compress = compress;
            Retention = retention;
            PackageSize = packageSize;
            CreatedBy = createdBy;
            Status = status;
            Sources = sources;
        }

        public string Type { get; set; }
        public string RepeatPeriod { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Compress { get; set; }
        public int Retention { get; set; }
        public int PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
        public List<SourceResultGet> Sources { get; set; }

        public Config Execute()
        {

            Config config = new Config(this.Type, this.RepeatPeriod, this.ExpirationDate, this.Compress, this.Retention,
                this.PackageSize, this.CreatedBy, this.Status);
            
            context.Configs.Add(config);

            context.SaveChanges();

            
            foreach (var item in this.Sources)
            {
                context.Sources.Add(new Source(item.Path, config.id));
            }

            context.SaveChanges();
            return config;
        }


    }
}
