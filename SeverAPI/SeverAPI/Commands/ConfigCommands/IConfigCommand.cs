using SeverAPI.Results.DestinationResults;
using SeverAPI.Results.GroupResults;
using SeverAPI.Results.SourceResults;
using SeverAPI.Results.TaskResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public interface IConfigCommand
    {
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; }
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        public List<SourceResultPost>? Sources { get; set; }
        public List<DestinationResultPost>? Destinations { get; set; }
        public List<TaskResultPost>? Tasks { get; set; }
        public List<GroupResultConfigPost>? groupIDs { get; set; }
    }
}
