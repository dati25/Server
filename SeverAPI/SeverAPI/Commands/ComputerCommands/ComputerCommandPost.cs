using Microsoft.EntityFrameworkCore;
using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;
using SeverAPI.Results.TaskResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands;

public class ComputerCommandPost : ICommand
{
    public async Task<int?> ExecuteAsyncOld(ComputerResultPost computer)
    {
        ComputerTestCommands tests = new ComputerTestCommands();
        if (!tests.IsValidMac(computer.MacAddress) || !tests.IsValidIp(computer.IpAddress) || !tests.IsValidStatus(computer.Status))
            return null;

        Computer? c = null;

        try
        {
            c = await context.Computers!.Where(x => x.MacAddress == computer.MacAddress).FirstAsync();
        }
        catch (Exception) { }

        if (c == null)
        {
            context.Computers!.Add(new Computer(computer.MacAddress, computer.IpAddress, computer.Name));
            await context.SaveChangesAsync();

            c = await context.Computers!.Where(x => x.MacAddress == computer.MacAddress).FirstAsync();

            Computer output = new Computer(c.MacAddress, c.IpAddress, c.Name, c.Status) { Id = c.Id };

            return output.Id;
        }
        else
        {
            c.IpAddress = computer.IpAddress;
            c.Name = computer.Name;
            await context.SaveChangesAsync();

            Computer output = new Computer(c.MacAddress, c.IpAddress, c.Name, c.Status) { Id = c.Id };

            if (context.Tasks == null)
                return output.Id;

            List<TaskResult>? configs = new List<TaskResult>();

            try
            {
                await context.Tasks!.Where(t => t.IdPc == c.Id).ToListAsync().ContinueWith(t =>
                {
                    foreach (Tasks task in t.Result)
                    {
                        configs.Add(new TaskResult(task.IdConfig));
                    }
                });

                return output.Id;
            }
            catch (Exception) { }

            return output.Id;
        }
    }
    public Computer Execute(ComputerResultPost computerPost)
    {
        ComputerTestCommands tests = new ComputerTestCommands();
        Computer computer = new Computer(computerPost.MacAddress, computerPost.IpAddress, computerPost.Name, computerPost.Status);

        tests.CheckAll(computer);

        context.Add(computer);
        context.SaveChanges();

        return computer;


    }


}