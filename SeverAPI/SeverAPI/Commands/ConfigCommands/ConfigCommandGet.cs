using SeverAPI.Results.ConfigResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigCommandGet : Command
    {
        public List<ConfigResultGet> Execute(int? inputCount, int offset = 0)
        {
            List<ConfigResultGet>? configsList = new List<ConfigResultGet>();
            context.Configs!.ToList().ForEach(x => configsList.Add(new ConfigResultGet(x)));

            if (inputCount == null && offset == 0)
                return configsList;

            int count = inputCount ?? configsList.Count;
            if (count <= 0 || offset >= configsList.Count)
                return null!;

            count = this.CheckCount(configsList, count);
            List<ConfigResultGet>? ResultConfig = new List<ConfigResultGet>();

            for (int i = offset; i < count; i++)
                ResultConfig.Add(configsList[i]);

            return ResultConfig!;
        }

        public int CheckCount<T>(List<T> list, int count)
        {
            if (list.Count <= count)
                return list.Count;

            return count;
        }
    }
}
