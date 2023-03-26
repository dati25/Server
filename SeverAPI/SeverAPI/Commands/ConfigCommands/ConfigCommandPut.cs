using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;
using SeverAPI.Results.DestinationResults;
using SeverAPI.Results.TaskResults;
namespace SeverAPI.Commands.ConfigCommands;

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

    public Config Execute(int id)
    {
        Config? config = context.Configs!.Find(id);

        if (config == null)
            return null!;

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
        config.Tasks = Tasks ?? config.Tasks;

        context.SaveChanges();

        return config;
    }
}