using Server.Database.Models;
using Server.Results.SourceResults;
using Server.Results.DestinationResults;
using Server.Results.TaskResults;
using Microsoft.EntityFrameworkCore.Design;
using Server.Results.GroupResults;
using System.Threading.Tasks;
using ZstdNet;
//using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Server.Commands.ConfigCommands;

public class ConfigCommandPost : ICommand
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
    public List<TaskResultPost>? Tasks { get; set; }
    public List<GroupResultConfigPost>? groupIDs { get; set; }

    public ConfigCommandPost(string type, string? repeatPeriod, DateTime? expirationDate, bool? compress, int? retention, int? packageSize, int createdBy, bool? status, List<SourceResultPost>? sources, List<DestinationResultPost>? destinations, List<TaskResultPost>? tasks, List<GroupResultConfigPost> groupIDs)
    {
        this.Type = type;
        this.RepeatPeriod = repeatPeriod;
        this.ExpirationDate = expirationDate;
        this.Compress = compress;
        this.Retention = retention;
        this.PackageSize = packageSize;
        this.CreatedBy = createdBy;
        this.Status = status;
        this.Sources = sources;
        this.Destinations = destinations;
        this.Tasks = tasks;

        if (groupIDs != null)
        {
            this.Tasks = this.Tasks ?? new List<TaskResultPost>();
            List<Group> groups = new List<Group>();
            groupIDs.ForEach(groupID => groups.AddRange(context.Groups!.ToList().Where(group => group.Id == groupID.id)));
            groups.ForEach(group => context.PcGroups!.Where(pcGroup => pcGroup.IdGroup == group.Id).ToList().ForEach(pcGroup => this.Tasks.Add(new TaskResultPost(pcGroup.IdPc))));
        }
    }
    public ConfigCommandPost(Config config)
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
        this.Tasks = new List<TaskResultPost>();

        config.Sources!.ForEach(x => this.Sources!.Add(new SourceResultPost(x.Path)));
        config.Destinations!.ForEach(x => this.Destinations!.Add(new DestinationResultPost(x.Type,x.Path)));
        config.Tasks!.ForEach(x => this.Tasks!.Add(new TaskResultPost(x.IdPc)));
    }

    public Config Execute()
    {
        Config config = new Config(Type, RepeatPeriod, ExpirationDate, Compress, Retention, PackageSize, CreatedBy, Status);

        context.Configs!.Add(config);

        context.SaveChanges();

        if (this.Sources! != null)
            foreach (var item in Sources!)
                context.Sources!.Add(new Source(config.Id, item.Path));

        if (this.Destinations! != null)
            foreach (var item in Destinations!)
                context.Destinations!.Add(new Destination(config.Id, item.Type, item.Path));

        if (this.Tasks! != null)
            foreach (var item in Tasks!)
                context.Tasks!.Add(new Tasks(item.IdPc, config.Id));


        context.SaveChanges();
        return config;
    }
    public string AlterPaths()
    {
        this.Sources!.ForEach(source => source.Path.Replace(@"\", "/"));
        this.Destinations!.ForEach(destination => destination.Path.Replace(@"\", "/"));

        return "";

    } //Useless asi
}