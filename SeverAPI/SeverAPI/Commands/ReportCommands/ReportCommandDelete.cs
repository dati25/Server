using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandDelete : Command
    {
        public void Execute(int id)
        {
            Report? report = context.Reports.Find(id);

            if (report == null)
                return;

            context.Reports.Remove(report!);
            context.SaveChanges();
        }
    }
}
