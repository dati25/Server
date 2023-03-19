using SeverAPI.Results.ReportResults;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandGet : Command
    {
        public List<ReportResultGet> Execute()
        {
            List<ReportResultGet>? ResultReports = new List<ReportResultGet>();
            context.Reports.ToList().ForEach(x => ResultReports.Add(new ReportResultGet(x)));

            return ResultReports!;
        }
    }
}
