using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table ("tbDestinations")]
    public class Destination
    {
        public int id { get; set; }
        public int idConfig { get; set; }
        public bool Type { get ; set; }
        public string Config { get; set; }

        public Destination(int idConfig, bool type, string config)
        {
            this.idConfig = idConfig;
            Type = type;
            Config = config;
        }

    }
}
