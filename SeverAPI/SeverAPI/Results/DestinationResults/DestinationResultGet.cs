using SeverAPI.Database.Models;
namespace SeverAPI.Results.DestinationResults
{
    public class DestinationResultGet
    {
        public string Type { get; set; }
        public string Configuration { get; set; }

        public DestinationResultGet(Destination destination)
        {
            this.Type = destination.Type == false ? "fil" : "ftp";
            this.Configuration = destination.Configuration;
        }
    }
}
