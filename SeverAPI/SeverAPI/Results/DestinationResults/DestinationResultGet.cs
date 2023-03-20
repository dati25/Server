using SeverAPI.Database.Models;

namespace SeverAPI.Results.DestinationResults
{
    public class DestinationResultGet
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

        public DestinationResultGet(Destination destination)
        {
            this.id = destination.id;
            this.Type = destination.Type == false ? "fil" : "ftp";
            this.Path = destination.Path;
        }
    }
}
