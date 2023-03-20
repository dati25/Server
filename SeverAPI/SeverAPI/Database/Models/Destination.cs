using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbDestinations")]
    public class Destination : IModel
    {
        public int id { get; set; }
        public int? idConfig { get; set; }
        public bool Type { get; set; }
        public string Path { get; set; }

        public Destination(int? idConfig, bool type, string path)
        {
            this.idConfig = idConfig;
            Type = type;
            Path = path;
        }

    }
}
