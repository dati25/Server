namespace SeverAPI.Results.SourceResults;

public class SourceResultPost : ISource
{
    public string Path { get; set; }

    public SourceResultPost(string path)
    {
        Path = path;
    }
}