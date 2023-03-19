using SeverAPI.Database.Models;

namespace SeverAPI.Commands
{
    public abstract class Command
    {
        protected MyContext context = new MyContext();
    }
}
