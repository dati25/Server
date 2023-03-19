using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandDelete : Command
    {
        public Report Execute(int id)
        {
            Report? report = context.Reports.Find(id);

            if (report == null)
                return null!;

            context.Reports.Remove(report!);
            context.SaveChanges();

            return report;
        }
    }
}
