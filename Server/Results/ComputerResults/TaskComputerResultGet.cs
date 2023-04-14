using Server.Database.Models;

namespace Server.Results.ComputerResults
{
    public class TaskComputerResultGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskComputerResultGet(Computer pc)
        {
            this.Id = pc.Id;
            this.Name = pc.Name;
        }
    }
}
