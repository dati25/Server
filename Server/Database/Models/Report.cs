using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models;

[Table("tbReports")]
public class Report : IModel
{
    public int Id { get; set; }
    public int IdConfig { get; set; }
    public string IdPc { get; set; }
    public char Status { get; set; }
    public DateTime ReportTime { get; set; }
    public string? Description { get; set; }

    public Report(string idPc, int idConfig, char status, DateTime reportTime, string? description)
    {
        this.IdPc = idPc;
        this.IdConfig = idConfig;
        this.Status = status;
        this.ReportTime = reportTime;
        this.Description = description;
    }
}