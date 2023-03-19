using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPost : Command
    {
        public ComputerResultPost Execute(ComputerResultPost computer)
        {
            this.context.Add(new Computer(computer.Name, computer.MacAddress, computer.IPAddress, computer.Status));
            this.context.SaveChanges();

            return computer;
        }
    }
}
