using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using SeverAPI.Results.DestinationResults;
using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandPost : ICommand
    {

        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; }
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        public List<SourceResultPost>? SourceResultPosts { get; set; }
        public List<DestinationResultPost>? DestinationResultPosts { get; set; }
        public List<TaskResultPost>? TasksResultPost { get; set; }

        public ConfigCommandPost(string type, string? repeatPeriod, DateTime? expirationDate, bool? compress, int? retention, int? packageSize, int createdBy, bool? status, List<SourceResultPost>? sources, List<DestinationResultPost>? destinations, List<TaskResultPost>? tasks)
        {
            Type = type;
            RepeatPeriod = repeatPeriod;
            ExpirationDate = expirationDate;
            Compress = compress;
            Retention = retention;
            PackageSize = packageSize;
            CreatedBy = createdBy;
            Status = status;
            SourceResultPosts = sources;
            this.DestinationResultPosts = destinations;
            this.TasksResultPost = tasks;
        }

        public Config Execute()
        {
            Config config = new Config(this.Type, this.RepeatPeriod, this.ExpirationDate, this.Compress, this.Retention,
                this.PackageSize, this.CreatedBy, this.Status);

            context.Configs!.Add(config);
            if (context.Admins!.Find(CreatedBy) == null)
                return null!;
            context.SaveChanges();


            foreach (var item in this.SourceResultPosts!)
                context.Sources!.Add(new Source(config.id, item.Path));

            foreach (var item in this.DestinationResultPosts!)
                context.Destinations!.Add(new Destination(config.id, item.Type, item.Path));

            foreach (var item in TasksResultPost!)
                context.Tasks!.Add(new Tasks(item.idPC, config.id));


            context.SaveChanges();
            return config;
        }
    }
}
