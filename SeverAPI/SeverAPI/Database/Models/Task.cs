using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models
{
    [Table("tbTasks")]
    public class Task : IModel
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public int idConfig { get; set; }   

        public Task(int idPC, int idConfig)
        {
            this.idPC = idPC;
            this.idConfig = idConfig;
        }
    }
}
