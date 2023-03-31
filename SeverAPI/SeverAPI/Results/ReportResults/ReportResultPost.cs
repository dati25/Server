namespace SeverAPI.Results.ReportResults;

public class ReportResultPost
{
    public int IdPc { get; set; }
    public bool? Status { get; set; }
    public string? Description { get; set; }

    public ReportResultPost(int idPc, bool? status, string? description)
    {
        IdPc = idPc;
        Status = status;
        Description = description;
    }
}