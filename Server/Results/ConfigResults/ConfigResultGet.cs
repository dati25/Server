using Server.Database.Models;
using Server.Results.DestinationResults;
using Server.Results.SourceResults;
using Server.Results.TaskResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Server.Results.ConfigResults;

public class ConfigResultGet
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string? RepeatPeriod { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool? Compress { get; set; }
    public int? Retention { get; set; }
    public int? PackageSize { get; set; }
    public int CreatedBy { get; set; }
    public bool? Status { get; set; }
    [ForeignKey("IdConfig")] public List<SourceResultGet> Sources { get; set; } = new List<SourceResultGet>();
    [ForeignKey("IdConfig")] public List<DestinationResultGet> Destinations { get; set; } = new List<DestinationResultGet>();
    [ForeignKey("IdConfig")] public List<TaskResultGet> Tasks { get; set; } = new List<TaskResultGet>();
    //public List<Server.Database.Models.Group> Groups { get; set; } = new List<Server.Database.Models.Group>();
    MyContext context = new MyContext();


    public ConfigResultGet(Config config)
    {
        Id = config.Id;
        Type = config.Type;
        RepeatPeriod = config.RepeatPeriod;
        ExpirationDate = config.ExpirationDate;
        Compress = config.Compress;
        Retention = config.Retention;
        PackageSize = config.PackageSize;
        CreatedBy = config.CreatedBy;
        Status = config.Status;
        context.Sources!.Where(x => x.IdConfig == config.Id).ToList().ForEach(x => Sources.Add(new SourceResultGet(x)));
        context.Destinations!.Where(x => x.IdConfig == config.Id).ToList().ForEach(x => Destinations.Add(new DestinationResultGet(x)));
        context.Tasks!.Where(x => x.IdConfig == config.Id).ToList().ForEach(x => Tasks.Add(new TaskResultGet(x)));
    }

}