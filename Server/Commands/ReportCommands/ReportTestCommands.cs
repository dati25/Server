using Server.Database.Models;

namespace Server.Commands.ReportCommands
{
    public class ReportTestCommands : ICommand
    {
        private Report report;
        public ReportTestCommands(Report report)
        {
            this.report = report;
        }
        public Dictionary<string, List<string>> CheckAll()
        {
            Dictionary<string, List<string>> expections = new Dictionary<string, List<string>>();

            if (!this.tester.CheckExistence(this.report))
                return this.tester.AddOrApend(expections, "Computer", "doesn't exist");

            if (!this.tester.CheckExistence(this.context.Computers!.Find(this.report.IdPc)!))
            {
                return this.tester.AddOrApend(expections, "IDPC", "Related PC doesn't exist");
            }

            return this.CheckConnection(expections, "RelationException");
        }
        private Dictionary<string, List<string>> CheckConnection(Dictionary<string, List<string>> dic, string key)
        {
            var pc= this.context.Computers!.Find(report.IdPc);

            if (pc == null)
                this.tester.AddOrApend(dic, "IdPC", "PC doens't exist.");

            var group = this.context.Groups!.Where(group => group.Name == "pc_" + pc!.Name).First();

            List<Tasks> tasks = this.context.Tasks!.Where(task => task.IdConfig == this.report.IdConfig && task.IdGroup == group.Id).ToList();

            if (tasks.Count == 0)
                return this.tester.AddOrApend(dic, key, "No association between IdPC and IdConfig.");
            return dic;
        }



    }
}
