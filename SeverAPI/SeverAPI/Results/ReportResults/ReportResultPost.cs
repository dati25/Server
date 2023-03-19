namespace SeverAPI.Results.ReportResults
{
    public class ReportResultPost
    {
        public int idPC { get; set; }
        public bool Status { get; set; }
        public DateTime? ReportTime { get; set; }
        public string? Description { get; set; }

        public ReportResultPost(int idPC, bool status, DateTime? reportTime, string? description)
        {
            this.idPC = idPC;
            Status = status;
            ReportTime = reportTime;
            Description = description;
        }
    }
}
