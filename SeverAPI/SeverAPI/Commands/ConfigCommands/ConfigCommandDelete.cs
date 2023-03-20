using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandDelete : Command
    {
        public Config Execute(int id)
        {
            Config? config = context.Configs!.Find(id);

            if (config == null)
                return null!;

            context.Configs.Remove(config);
            context.SaveChanges();

            return config;
        }

        public Config DeleteSource(int id, int sourceID)
        {
            Config? config = context.Configs!.Find(id);
            Source? source = context.Sources!.Find(sourceID);

            if (config == null || source == null)
                return null!;

            config.Sources!.Remove(source);
            context.SaveChanges();

            return config;
        }

        public Config DeleteDestination(int id, int destinationID)
        {
            Config? config = context.Configs!.Find(id);
            Destination? destination = context.Destinations!.Find(destinationID);

            if (config == null || destination == null)
                return null!;

            config.Destinations!.Remove(destination);
            context.SaveChanges();

            return config;
        }

        public Config DeleteTask(int id, int taskID)
        {
            Config? config = context.Configs!.Find(id);
            Tasks? task = context.Tasks!.Find(taskID);

            if (config == null || task == null)
                return null!;

            config.Tasks!.Remove(task);
            context.SaveChanges();

            return config;
        }
    }
}
