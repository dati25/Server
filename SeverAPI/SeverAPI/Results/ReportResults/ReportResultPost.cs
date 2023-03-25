namespace SeverAPI.Results.ReportResults;

public class ReportResultPost
{
    public int IdPc { get; set; }
    public bool? Status { get; set; }
    public DateTime ReportTime { get; set; }
    public string? Description { get; set; }

    public ReportResultPost(int idPc, bool? status, DateTime reportTime, string? description)
    {
        IdPc = idPc;
        Status = status;
        ReportTime = reportTime;
        Description = description;
    }
}