using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandGet : Command
    {
        public List<ComputerResultGet> Execute()
        {
            List<ComputerResultGet>? ResultComputers = new List<ComputerResultGet>();
            context.Computers.ToList().ForEach(x => ResultComputers.Add(new ComputerResultGet(x)));

            return ResultComputers!;
        }
    }
}
