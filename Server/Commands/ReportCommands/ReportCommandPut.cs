using Server.Database.Models;

namespace Server.Commands.ReportCommands
{
    public class ReportCommandPut : ICommand
    {
        public int? idPC { get; set; }
        public char? status { get; set; }
        public DateTime? reportTime { get; set; }
        public string? description { get; set; }

        public ReportCommandPut(int? idPC, char? status, DateTime? reportTime, string? description)
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

            report.IdPc = idPC ?? report.IdPc;
            report.Status = status ?? report.Status;
            report.ReportTime = reportTime ?? report.ReportTime;
            report.Description = description ?? report.Description;

            context.SaveChanges();
            return report;
        }
    }
}
