using Server.Commands.AdminCommands;
using Server.Database.Models;
namespace Server.Commands;

public class CommandsGetDelete : ICommand
{
    public List<T> Get<T>(List<T> list, int? inputCount, int offset = 0) where T : class
    {
        if (inputCount == null && offset == 0)
            return list;

        int count = inputCount ?? list.Count;
        if (count <= 0 || offset >= list.Count)
            return null!;

        count = CheckCount(list, count);
        List<T>? resultList = new List<T>();
        for (int i = offset; i < count + offset && i < list.Count; i++)
            resultList.Add(list[i]);

        return resultList;
    }

    public List<int> GetConfigsFromidPC(int idPC)
    {
        List<int> results = new List<int>();

        
        Computer pc = this.context.Computers!.Find(idPC)!;
        if (pc == null)
            return null!;

        List<PcGroups> psg = this.context.PcGroups!.Where(psg => psg.IdPc == idPC).ToList();

        List<Group> groups = new List<Group>();
        psg.ForEach(psg => groups.AddRange(this.context.Groups!.Where(group => group.Id == psg.IdGroup)));
        List<Tasks> tasks = new List<Tasks>();
        groups.ForEach(group => tasks.AddRange(this.context.Tasks!.Where(task => task.IdGroup == group.Id)));
        tasks.ForEach(task=> results.Add(task.IdConfig));
        results = results.Distinct().ToList();
        return results;
    }

    public bool Delete<T>(T deletedObject) where T : class
    {
        if (!this.tester.CheckExistence(deletedObject))
            return false;

        context.Remove(deletedObject);
        context.SaveChanges();
        return true;
    }

    public int CheckCount<T>(List<T> list, int count)
    {
        if (count >= list.Count)
            return list.Count;

        return count;
    }
}