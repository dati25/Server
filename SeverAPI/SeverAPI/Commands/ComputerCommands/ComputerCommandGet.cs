using SeverAPI.Results.ComputerResults;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandGet : Command
    {
        public List<ComputerResultGet> Execute(int? inputCount, int offset = 0)
        {
            List<ComputerResultGet>? computersList = new List<ComputerResultGet>();
            context.Computers.ToList().ForEach(x => computersList.Add(new ComputerResultGet(x)));

            if (inputCount == null && offset == 0)
                return computersList;

            int count = inputCount ?? computersList.Count;
            if (count <= 0 || offset >= computersList.Count)
                return null!;

            count = this.CheckCount(computersList, count);
            List<ComputerResultGet>? ResultComputer = new List<ComputerResultGet>();

            for (int i = offset; i < count; i++)
                ResultComputer.Add(computersList[i]);

            return ResultComputer!;
        }

        public int CheckCount<T>(List<T> list, int count)
        {
            if (list.Count <= count)
                return list.Count;

            return count;
        }
    }
}
