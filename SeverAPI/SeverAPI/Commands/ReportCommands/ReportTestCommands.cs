using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportTestCommands : ICommand
    {
        public Dictionary<string, string> CheckAll(Report report)
        {
            Dictionary<string, string> expections = new Dictionary<string, string>();

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
