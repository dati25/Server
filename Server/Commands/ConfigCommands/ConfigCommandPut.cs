using Server.Database.Models;
using Server.Results.SourceResults;
using Server.Results.DestinationResults;
using Server.Results.TaskResults;
using Server.Results.GroupResults;

namespace Server.Commands.ConfigCommands;

public class ConfigCommandPut
{
    public string? Name { get; set; }
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
    public List<TaskResultPost>? Groups { get; set; }
    public List<TaskResultComputerPost>? Computers { get; set; }


    public Config Execute(int id, MyContext context)
    {
        Config? config = context.Configs!.Find(id);
        if (config == null)
        {
            return null!;
        }
        config.Name = Name ?? config.Name;
        config.Type = Type ?? config.Type;
        config.RepeatPeriod = RepeatPeriod ?? config.RepeatPeriod;
        config.ExpirationDate = ExpirationDate ?? config.ExpirationDate;
        config.Compress = Compress ?? config.Compress;
        config.Retention = Retention ?? config.Retention;
        config.PackageSize = PackageSize ?? config.PackageSize;
        config.CreatedBy = CreatedBy ?? config.CreatedBy;
        config.Status = Status ?? config.Status;
        config.Sources = Sources ?? config.Sources;
        config.Destinations = Destinations ?? config.Destinations;
        if(Groups != null)
        {
            config.Tasks = new List<Tasks>();
            Groups.ForEach(group => config.Tasks.Add(new Tasks(group.IdGroup, id)));
        }
        if(Computers != null)
        {
            config.Tasks = config.Tasks ?? new List<Tasks>();
            Computers!.ForEach(pc =>
            {
                var groups = context.Groups!.ToList();
                Group group = groups.Where(group => group.Name.Substring(3) == context.Computers!.Find(pc.IdPc)!.Name && group.Name.StartsWith("pc_")).First();
                config.Tasks!.Add(new Tasks(group.Id,config.Id));
            });

        }
        return config;
    }
}