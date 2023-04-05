using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models;

[Table("tbReports")]
public class Report : IModel
{
    public int Id { get; set; }
    public int IdPc { get; set; }
    public bool? Status { get; set; }
    public DateTime ReportTime { get; set; }
    public string? Description { get; set; }

    public Report(int idPc, bool? status, DateTime reportTime, string? description)
    {
        IdPc = idPc;
        Status = status;
        ReportTime = reportTime;
        Description = description;
    }
}