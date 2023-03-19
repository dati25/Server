using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models
{
    [Table("tbSources")]
    public class Source
    {

        [JsonIgnore] public int id { get; set; }
        public string Path { get; set; }
        [JsonIgnore] public int idConfig { get; set; }
        [JsonIgnore] public Config Config { get; set; }
        public Source(string path, int idConfig)
        {
            Path = path;
            this.idConfig = idConfig;
        }
    }
}
