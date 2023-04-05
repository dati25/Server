using Server.Database.Models;
using Server.Results.SourceResults;
using Server.Results.DestinationResults;
using Server.Results.TaskResults;
using Server.Results.GroupResults;

namespace Server.Commands.ConfigCommands;

public class ConfigCommandPut : ICommand
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
    public List<Destination>? Destinations { get; set; }
    public List<Tasks>? Tasks { get; set; }
    public List<GroupResultConfigPost>? groupIDs { get; set; }


    public Config Execute(int id)
    {
        Config? config = context.Configs!.Find(id);

        config!.Type = Type ?? config.Type;
        config.RepeatPeriod = RepeatPeriod ?? config.RepeatPeriod;
        config.ExpirationDate = ExpirationDate ?? config.ExpirationDate;
        config.Compress = Compress ?? config.Compress;
        config.Retention = Retention ?? config.Retention;
        config.PackageSize = PackageSize ?? config.PackageSize;
        config.CreatedBy = CreatedBy ?? config.CreatedBy;
        config.Status = Status ?? config.Status;
        config.Sources = Sources ?? config.Sources;
        config.Destinations = Destinations ?? config.Destinations;
        config.Tasks = Tasks ?? config.Tasks;

        if (groupIDs != null)
        {
            config.Tasks = config.Tasks ?? new List<Tasks>();
            List<Group> groups = new List<Group>();
            groupIDs.ForEach(groupID => groups.AddRange(context.Groups!.ToList().Where(group => group.Id == groupID.id)));
            groups.ForEach(group => context.PcGroups!.Where(pcGroup => pcGroup.IdGroup == group.Id).ToList().ForEach(pcGroup => config.Tasks!.Add(new Tasks(pcGroup.IdPc, id))));
        }

        this.Tasks!.DistinctBy(x => x.IdPc);

        return config;
    }
}