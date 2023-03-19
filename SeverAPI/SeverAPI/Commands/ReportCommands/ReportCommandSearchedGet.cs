using SeverAPI.Database.Models;
using SeverAPI.Results.ReportResults;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandSearchedGet : Command
    {
        public ReportResultGet Execute(int id)
        {
            if (context.Reports.Find(id) == null)
                return null!;

            Report? report = context.Reports.Find(id);

            return new ReportResultGet(report!);
        }
    }
}
