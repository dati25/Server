using SeverAPI.Database.Models;

namespace SeverAPI.Results.DestinationResults;

public class DestinationResultGet
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Path { get; set; }

    public DestinationResultGet(Destination destination)
    {
        Id = destination.Id;
        Type = destination.Type == false ? "fil" : "ftp";
        Path = destination.Path;
    }
}