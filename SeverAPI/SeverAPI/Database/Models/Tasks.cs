using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbTasks")]
    public class Tasks : IModel
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public int idConfig { get; set; }   
        public bool? Status { get; set; }

        public Tasks(int idPC, int idConfig, bool? status)
        {
            this.idPC = idPC;
            this.idConfig = idConfig;
            this.Status = status;
        }
    }
}
