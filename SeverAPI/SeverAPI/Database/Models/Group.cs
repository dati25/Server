using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbGroups")]
    public class Group : IModel
    {//Incomplete
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey("idGroup")] public List<PCGroups>? PCGroups { get; set; }

        public Group(string Name)
        {
            this.Name = Name;
        }
    }
}
