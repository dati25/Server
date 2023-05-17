namespace Server.Results.ReportResults;

public class ReportResultPost
{
    public int IdPc { get; set; }
    public int IdConfig { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; }

    public ReportResultPost(int idPc, int idConfig, bool status, string? description = null)
    {
        this.IdPc = idPc;
        this.IdConfig = idConfig;
        this.Status = status;
        this.Description = description;
    }
}