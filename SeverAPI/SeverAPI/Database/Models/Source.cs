using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbSources")]
    public class Source : IModel
    {
        public int id { get; set; }
        public int? idConfig { get; set; }
        public string Path { get; set; }

        public Source(int? idConfig, string Path)
        {
            this.idConfig = idConfig;
            this.Path = Path;
        }
    }
}
