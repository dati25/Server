namespace Server.Results.ReportResults;

public class ReportResultPost
{
    public string IdPc { get; set; }
    public int IdConfig { get; set; }
    public char Status { get; set; }
    public string? Description { get; set; }

    public ReportResultPost(string idPc, int idConfig, char status, string? description = null)
    {
        this.IdPc = idPc;
        this.IdConfig = idConfig;
        this.Status = status;
        this.Description = description;
    }
}