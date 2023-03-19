using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table ("tbDestinations")]
    public class Destination : IModel
    {
        public int id { get; set; }
        public int idConfig { get; set; }
        public bool Type { get ; set; }
        [Column ("Config")]
        public string Configuration { get; set; }

        public Destination(int idConfig, bool type, string configuration)
        {
            this.idConfig = idConfig;
            Type = type;
            Configuration = configuration;
        }

    }
}
