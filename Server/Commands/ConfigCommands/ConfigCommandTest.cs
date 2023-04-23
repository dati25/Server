using Server.Results.DestinationResults;
using Server.Results.GroupResults;
using Server.Results.SourceResults;
using Server.Results.TaskResults;
using Server.Database.Models;
using MySqlX.XDevAPI.Common;

namespace Server.Commands.ConfigCommands
{
    public class ConfigCommandTest
    {
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; } = false;
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        public List<SourceResultPost>? Sources { get; set; }
        public List<DestinationResultPost>? Destinations { get; set; }
        public List<int>? Computers { get; set; } = new List<int>();
        public List<int>? Groups { get; set; } = new List<int>();
        public ConfigCommandTest(Config config, MyContext context)
        {
            this.Type = config.Type;
            this.RepeatPeriod = config.RepeatPeriod;
            this.ExpirationDate = config.ExpirationDate;
            this.Compress = config.Compress;
            this.Retention = config.Retention;
            this.PackageSize = config.PackageSize;
            this.CreatedBy = config.CreatedBy;
            this.Status = config.Status;
            this.Sources = new List<SourceResultPost>();
            this.Destinations = new List<DestinationResultPost>();
            if (config.Sources != null)
                config.Sources!.ForEach(x => this.Sources!.Add(new SourceResultPost(x.Path)));
            if (config.Destinations != null)
                config.Destinations!.ForEach(x => this.Destinations!.Add(new DestinationResultPost(x.Type, x.Path)));
            if (config.Tasks != null)
            {
                List<Group> groups = context.Groups!.ToList().Where(group => config.Tasks.Any(task => task.IdGroup.Equals(group.Id)) && !group.Name.StartsWith("pc_")).ToList();
                groups.ForEach(x => this.Groups!.Add(x.Id));

                //IEnumerable<Group> pcGroups = context.Groups!.ToList().Where(group => !groups.Any(confGroups => confGroups.Id == group.Id));
                List<Group> pcGroups = context.Groups!.ToList().Where(group => config.Tasks.Any(task => task.IdGroup == group.Id) && group.Name.StartsWith("pc_")).ToList();
                pcGroups.ToList().ForEach(group => this.Computers.Add(context.Computers!.ToList().Where(pc => pc.Name == group.Name.Substring(3))!.First().Id));

            }
        }
        public ConfigCommandTest(ConfigCommandPost config)
        {
            this.Type = config.Type;
            this.RepeatPeriod = config.RepeatPeriod;
            this.ExpirationDate = config.ExpirationDate;
            this.Compress = config.Compress;
            this.Retention = config.Retention;
            this.PackageSize = config.PackageSize;
            this.CreatedBy = config.CreatedBy;
            this.Status = config.Status;

            if (config.Sources != null)
            {
                this.Sources = new List<SourceResultPost>();
                config.Sources!.ForEach(x => this.Sources!.Add(new SourceResultPost(x.Path)));
            }
            if (config.Destinations != null)
            {
                this.Destinations = new List<DestinationResultPost>();
                config.Destinations!.ForEach(x => this.Destinations!.Add(new DestinationResultPost(x.Type, x.Path)));
            }

            if (config.Groups != null)
                config.Groups.ForEach(x => this.Groups!.Add(x.IdGroup));

            if (config.Computers != null)
                config.Computers.ForEach(x => this.Computers!.Add(x.IdPc));

        }
    }
}
