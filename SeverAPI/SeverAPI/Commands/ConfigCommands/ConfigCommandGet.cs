using Microsoft.EntityFrameworkCore;
using SeverAPI.Results.ConfigResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandGet : Command
    {
        public List<ConfigResultGet> Execute()
        {
            List<ConfigResultGet> configResults = new List<ConfigResultGet>();
            context.Configs.Include(x => x.Sources).Include(x => x.Destinations).Include(x => x.Tasks).ToList().ForEach(x => configResults.Add(new ConfigResultGet(x)));
            return configResults;
        }
    }
}
