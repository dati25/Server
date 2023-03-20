using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbPCGroups")]
    public class PCGroups : IModel
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public int idGroup { get; set; }

        public PCGroups(int idPC, int idGroup)
        {
            this.idPC = idPC;
            this.idGroup = idGroup;
        }
    }
}
