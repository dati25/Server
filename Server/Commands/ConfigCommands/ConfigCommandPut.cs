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
        config.Name = this.Name ?? config.Name;
        config.Type = this.Type ?? config.Type;
        config.ExpirationDate = this.ExpirationDate ?? config.ExpirationDate;
        config.Compress = this.Compress ?? config.Compress;
        config.Retention = this.Retention ?? config.Retention;
        config.PackageSize = this.PackageSize ?? config.PackageSize;
        config.CreatedBy = this.CreatedBy ?? config.CreatedBy;
        config.Status = this.Status ?? config.Status;
        config.Sources = this.Sources ?? config.Sources;
        config.Destinations = this.Destinations ?? config.Destinations;

        if(this.RepeatPeriod != null)
        {
            var tester = new Tester();
            config.RepeatPeriod = tester.QuestionMarkChange(this.RepeatPeriod);
        }
        //if (Groups != null && Computers != null)
        //    return;
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