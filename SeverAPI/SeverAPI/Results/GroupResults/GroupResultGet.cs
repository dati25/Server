using SeverAPI.Results.PCGroupResults;
using SeverAPI.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Results.GroupResults
{
    public class GroupResultGet
    {
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey("idGroup")] public List<PCGroupResultGet> PCGroups { get; set; } = new List<PCGroupResultGet>();
        MyContext context = new MyContext();

        public GroupResultGet(Group group)
        {
            this.id = group.id;
            Name = group.Name;
            context.PCGroups!.Where(x => x.idGroup == group.id).ToList().ForEach(x => this.PCGroups.Add(new PCGroupResultGet(x)));
        }
    }
}
