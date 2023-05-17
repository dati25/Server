using Server.Database.Models;
using Server.Results.SourceResults;
using Server.Results.DestinationResults;
using Server.Results.TaskResults;

namespace Server.Commands.ConfigCommands;

public class ConfigCommandPost : ICommand
{
    public string Name { get; set; }
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
    public List<TaskResultPost>? Groups { get; set; }
    public List<TaskResultComputerPost>? Computers { get; set; }

    public ConfigCommandPost(string name, string type, string? repeatPeriod, DateTime? expirationDate, bool? compress, int? retention, int? packageSize, int createdBy, bool? status, List<SourceResultPost>? sources, List<DestinationResultPost>? destinations, List<TaskResultPost>? Groups, List<TaskResultComputerPost>? Computers)
    {
        this.Name = name;
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
        this.Groups = Groups;
        this.Computers = Computers;
    }


    public Config Execute(MyContext myContext)
    {
        Config config = new Config(Name, Type, this.tester.QuestionMarkChange(RepeatPeriod!), ExpirationDate, Compress, Retention, PackageSize, CreatedBy, Status);

        myContext.Configs!.Add(config);

        myContext.SaveChanges();

        if (this.Sources! != null)
            this.Sources!.ForEach(source => myContext.Sources!.Add(new Source(config.Id, source.Path)));

        if (this.Destinations! != null)
            this.Destinations.ForEach(dest => myContext.Destinations!.Add(new Destination(config.Id, dest.Type, dest.Path)));

        if (this.Groups! != null)
            this.Groups.ForEach(group => myContext.Tasks!.Add(new Tasks(group.IdGroup, config.Id)));

        if (Computers != null)
            this.Computers.ForEach(pc =>
            {
                var groups = myContext.Groups!.ToList();
                Group group = groups.Where(group => group.Name.Substring(3) == myContext.Computers!.Find(pc.IdPc)!.Name && group.Name.StartsWith("pc_")).First();
                myContext.Tasks!.Add(new Tasks(group.Id, config.Id));
            });

        return config;
    }
}