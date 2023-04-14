﻿using Server.Commands.AdminCommands;

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

        //this.context.Tasks!.Where(x => x.IdPc == idPC).ToList().ForEach(task => results.Add(task.IdConfig));

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