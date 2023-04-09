using Server.Database.Models;

namespace Server.Commands.ReportCommands
{
    public class ReportTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckAll(Report report)
        {
            Dictionary<string, List<string>> expections = new Dictionary<string, List<string>>();

            if (!this.tester.CheckExistence(report))
                return this.tester.AddOrApend(expections, "Computer", "doesn't exist");

            if (!this.tester.CheckExistence(this.context.Computers!.Find(report.IdPc)!))
            {
                return this.tester.AddOrApend(expections, "IDPC", "Related PC doesn't exist");
            }

            return expections;
        }



    }
}
