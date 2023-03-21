using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ReportCommands
{
    public class ReportCommandPut : ICommand
    {
        public int? idPC { get; set; }
        public bool? status { get; set; }
        public DateTime? reportTime { get; set; }
        public string? description { get; set; }

        public ReportCommandPut(int? idPC, bool? status, DateTime? reportTime, string? description)
        {
            this.idPC = idPC;
            this.status = status;
            this.reportTime = reportTime;
            this.description = description;
        }

        public Report Execute(int id)
        {
            Report? report = context.Reports!.Find(id);

            if (report == null)
                return null!;

            report.idPC = idPC ?? report.idPC;
            report.Status = status ?? report.Status;
            report.ReportTime = reportTime ?? report.ReportTime;
            report.Description = description ?? report.Description;

            context.SaveChanges();

            return report;
        }
    }
}
