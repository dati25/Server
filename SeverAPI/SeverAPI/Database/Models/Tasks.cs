using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models
{
    [Table("tbTasks")]
    public class Tasks : IModel
    {
        [JsonIgnore] public int id { get; set; }
        public int idPC { get; set; }
        [JsonIgnore] public int idConfig { get; set; }   

        public Tasks(int idPC, int idConfig)
        {
            this.idPC = idPC;
            this.idConfig = idConfig;
        }
    }
}
