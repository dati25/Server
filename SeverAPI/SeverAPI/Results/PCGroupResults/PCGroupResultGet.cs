using SeverAPI.Database.Models;

namespace SeverAPI.Results.PCGroupResults
{
    public class PCGroupResultGet
    {
        public int id { get; set; }
        public int idPC { get; set; }

        public PCGroupResultGet(PCGroups pcGroup)
        {
            this.id = pcGroup.id;
            this.idPC = pcGroup.idPC;
        }
    }
}
