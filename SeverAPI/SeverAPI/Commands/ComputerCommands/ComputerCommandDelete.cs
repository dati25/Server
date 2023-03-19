using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandDelete : Command
    {
        public void Execute(int id)
        {
            Computer? computer = context.Computers.Find(id);

            if (computer == null)
                return;

            context.Computers.Remove(computer!);
            context.SaveChanges();
        }
    }
}
