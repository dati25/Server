using SeverAPI.Database.Models;
using SeverAPI.Results.ReportResults;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandSearchedGet : Command
    {
        public ReportResultGet Execute(int id)
        {
            Report? report = context.Reports.Find(id);

            if (report == null)
                return null!;

            return new ReportResultGet(report);
        }
    }
}
