using Server.Database.Models;

namespace Server.Results.DestinationResults;

public class DestinationResultGet
{
    public int Id { get; set; }
    public bool Type { get; set; }
    public string Path { get; set; }

    public DestinationResultGet(Destination destination)
    {
        Id = destination.Id;
        Type = destination.Type;
        Path = destination.Path;
    }
}