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
    }
}
