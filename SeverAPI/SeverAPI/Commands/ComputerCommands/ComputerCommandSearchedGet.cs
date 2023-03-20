using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandSearchedGet : Command
    {
        public ComputerResultGet Execute(int id)
        {
            if (context.Computers!.Find(id) == null)
                return null!;

            Computer? computer = context.Computers.Find(id);

            return new ComputerResultGet(computer!);
        }
    }
}
