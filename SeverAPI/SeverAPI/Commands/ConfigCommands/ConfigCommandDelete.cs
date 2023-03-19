using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using SeverAPI.Database.Models;
namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandDelete : Command
    {
        public void Execute(int id)
        {
            Config? config = context.Configs.Find(id);

            if (config == null)
                return;

            context.Configs.Remove(config);

            context.SaveChanges();
        }
        public void DeleteSource(int id, int sourceID)
        {
            Config? config = context.Configs.Find(id);

            Source? source = context.Sources.Find(sourceID);

            if (config == null || source == null)
                return;

            config.Sources.Remove(source);
            context.SaveChanges();
        }
        public void DeleteDestination(int id, int destinationID)
        {
            Config? config = context.Configs.Find(id);

            Destination? destination = context.Destinations.Find(destinationID);

            if (config == null || destination == null)
                return;

            config.Destinations.Remove(destination);
            context.SaveChanges();
        }
        public void DeleteTask(int id, int taskID)
        {
            Config? config = context.Configs.Find(id);

            Tasks? task = context.Tasks.Find(taskID);

            if (config == null || task == null)
                return;

            config.Tasks.Remove(task);
            context.SaveChanges();
        }
    }
}
