namespace SeverAPI.Results.DestinationResults;

public class DestinationResultPost
{
    public bool Type { get; set; }
    public string Path { get; set; }

    public DestinationResultPost(bool type, string path)
    {
        Type = type;
        Path = path;
    }
}