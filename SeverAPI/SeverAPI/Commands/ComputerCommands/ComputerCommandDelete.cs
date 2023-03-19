using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandDelete : Command
    {
        public Computer Execute(int id)
        {
            Computer? computer = context.Computers.Find(id);

            if (computer == null)
                return null!;

            context.Computers.Remove(computer!);
            context.SaveChanges();

            return computer;
        }
    }
}
