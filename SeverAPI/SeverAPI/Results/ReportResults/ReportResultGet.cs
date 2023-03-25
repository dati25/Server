using SeverAPI.Database.Models;

namespace SeverAPI.Results.ReportResults;

public class ReportResultGet
{
    public int Id { get; set; }
    public int IdPc { get; set; }
    public bool? Status { get; set; }
    public DateTime ReportTime { get; set; }
    public string? Description { get; set; }

    public ReportResultGet(Report report)
    {
        Id = report.Id;
        IdPc = report.IdPc;
        Status = report.Status;
        ReportTime = report.ReportTime;
        Description = report.Description;
    }
}