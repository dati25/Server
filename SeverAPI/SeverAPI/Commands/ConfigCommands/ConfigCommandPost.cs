using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandPost : Command
    {

        public string Type { get; set; }
        public string RepeatPeriod { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Compress { get; set; }
        public int Retention { get; set; }
        public int PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
        public List<Source> Sources { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Database.Models.Tasks> Tasks { get; set; }

        public ConfigCommandPost(string type, string repeatPeriod, DateTime expirationDate, bool compress, int retention, int packageSize, int createdBy, bool status, List<Source> sources, List<Destination> destinations, List<Database.Models.Tasks> tasks)
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
            this.Destinations = destinations; 
            this.Tasks = tasks;
        }
        public Config Execute()
        {

            Config config = new Config(this.Type, this.RepeatPeriod, this.ExpirationDate, this.Compress, this.Retention,
                this.PackageSize, this.CreatedBy, this.Status);

            context.Configs.Add(config);
            if (context.Admins.Find(CreatedBy) == null)
                return null;
            context.SaveChanges();


            foreach (var item in this.Sources)
            {
                context.Sources.Add(new Source() { Path = item.Path, idConfig = config.id });
            }
            foreach (var item in this.Destinations)
            {
                context.Destinations.Add(new Destination(config.id, item.Type, item.Configuration));
            }
            foreach (var item in Tasks)
            {
                context.Tasks.Add(new Database.Models.Tasks(item.idPC, config.id));
            }
            context.SaveChanges();
            return config;
        }


    }
}
