using SeverAPI.Results.ConfigResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandSearchedGet : Command
    {
        public ConfigResultGet Execute(int id)
        {
            Config? config = context.Configs!.Find(id);

            if (config == null)
                return null!;

            ConfigResultGet result = new ConfigResultGet(config);

            return result;
        }
    }
}
