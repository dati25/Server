using Server.Database.Models;

namespace Server.Results.SourceResults;

public class SourceResultGet
{
    public int Id { get; set; }
    public string Path { get; set; }

    public SourceResultGet(Source source)
    {
        Id = source.Id;
        Path = source.Path;
    }
}