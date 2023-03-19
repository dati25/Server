using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandSearchedGet : Command
    {
        public ComputerResultGet Execute(int id)
        {
            Computer? computer = context.Computers.Find(id);

            if (computer == null)
                return null!;

            return new ComputerResultGet(computer);
        }
    }
}
