using SeverAPI.Results.ReportResults;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandGet : Command
    {
        public List<ReportResultGet> Execute(int? inputCount, int offset = 0)
        {
            List<ReportResultGet>? reportsList = new List<ReportResultGet>();
            context.Reports.ToList().ForEach(x => reportsList.Add(new ReportResultGet(x)));

            if (inputCount == null && offset == 0)
                return reportsList;

            int count = inputCount ?? reportsList.Count;
            if (count <= 0 || offset >= reportsList.Count)
                return null!;

            count = this.CheckCount(reportsList, count);
            List<ReportResultGet>? ResultReport = new List<ReportResultGet>();

            for (int i = offset; i < count; i++)
                ResultReport.Add(reportsList[i]);

            return ResultReport!;
        }

        public int CheckCount<T>(List<T> list, int count)
        {
            if (list.Count <= count)
                return list.Count;

            return count;
        }
    }
}
