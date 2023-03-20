namespace SeverAPI.Results.DestinationResults
{
    public class DestinationResultPost
    {
        public bool Type { get; set; }
        public string Path { get; set; }

        public DestinationResultPost(bool Type, string Path)
        {
            this.Type = Type;
            this.Path = Path;
        }
    }
}
