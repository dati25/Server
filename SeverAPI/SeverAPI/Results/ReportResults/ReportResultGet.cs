using SeverAPI.Database.Models;

namespace SeverAPI.Results.ReportResults
{
    public class ReportResultGet : IModel
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public bool Status { get; set; }
        public DateTime? ReportTime { get; set; }
        public string? Description { get; set; }

        public ReportResultGet(Report report)
        {
            id = report.id;
            idPC = report.idPC;
            Status = report.Status;
            ReportTime = report.ReportTime;
            Description = report.Description;
        }
    }
}
