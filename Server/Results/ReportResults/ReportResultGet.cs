using Server.Database.Models;

namespace Server.Results.ReportResults;

public class ReportResultGet
{
    public int Id { get; set; }
    public int IdPc { get; set; }
    public int IdConfig { get; set; }
    public char Status { get; set; }
    public DateTime ReportTime { get; set; }
    public string? Description { get; set; }

    public ReportResultGet(Report report)
    {
        this.Id = report.Id;
        this.IdPc = report.IdPc;
        this.IdConfig = report.IdConfig;
        this.Status = report.Status;
        this.ReportTime = report.ReportTime;
        this.Description = report.Description;
    }
}