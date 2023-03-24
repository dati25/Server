using SeverAPI.Results.TaskResults;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResult
    {
        public int? idPC { get; set; }
        public List<TaskResult>? Tasks { get; set; }

        public ComputerResult(int? idPC, List<TaskResult>? tasks)
        {
            this.idPC = idPC;
            this.Tasks = tasks;
        }
    }
}