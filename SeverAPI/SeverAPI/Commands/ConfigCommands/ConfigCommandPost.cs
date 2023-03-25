using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using SeverAPI.Results.DestinationResults;
using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.ConfigCommands;

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
        DestinationResultPosts = destinations;
        TasksResultPost = tasks;
    }

    public Config Execute()
    {
        Config config = new Config(Type, RepeatPeriod, ExpirationDate, Compress, Retention, PackageSize, CreatedBy, Status);

        context.Configs!.Add(config);

        if (context.Admins!.Find(CreatedBy) == null)
            return null!;

        context.SaveChanges();


        foreach (var item in SourceResultPosts!)
            context.Sources!.Add(new Source(config.Id, item.Path));

        foreach (var item in DestinationResultPosts!)
            context.Destinations!.Add(new Destination(config.Id, item.Type, item.Path));

        foreach (var item in TasksResultPost!)
            context.Tasks!.Add(new Tasks(item.IdPc, config.Id));


        context.SaveChanges();
        return config;
    }
}