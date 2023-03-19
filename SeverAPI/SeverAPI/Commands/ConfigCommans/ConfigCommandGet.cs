using Microsoft.EntityFrameworkCore;
using SeverAPI.Results.ConfigResults;

namespace SeverAPI.Commands.ConfigCommans
{
    public class ConfigCommandGet : Command
    {
        public List<ConfigResultGet> Execute()
        {
            List<ConfigResultGet> configResults = new List<ConfigResultGet>();
            context.Configs.Include(x => x.Sources).ToList().ForEach(x => configResults.Add(new ConfigResultGet(x)));

            return configResults;
        }




    }
}
