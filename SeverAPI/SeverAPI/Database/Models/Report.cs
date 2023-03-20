using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbReports")]
    public class Report : IModel
    {
        public int id { get; set; }
        public int idPC { get; set; }
        public bool? Status { get; set; }
        public DateTime ReportTime { get; set; }
        public string? Description { get; set; }

        public Report(int idPC, bool? status, DateTime reportTime, string? description)
        {
            this.idPC = idPC;
            Status = status;
            ReportTime = reportTime;
            Description = description;
        }
    }
}
