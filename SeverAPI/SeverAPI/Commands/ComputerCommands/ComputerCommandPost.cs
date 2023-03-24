using Microsoft.EntityFrameworkCore;
using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;
using SeverAPI.Results.TaskResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPost : ICommand
    {
        public async Task<(int?, List<TaskResult>?)> Execute(ComputerResultPost computer)
        {
            //if ((!IsValidMac(computer.MacAddress)) || (!this.IsValidStatus(computer.Status)))
            //    return (null, null);

            Computer? c = null;

            try
            {
                c = await context.Computers!.Where(c => c.MacAddress == computer.MacAddress).FirstAsync();
            }
            catch (Exception) { }

            if (c == null)
            {
                context.Computers!.Add(new Computer(computer.MacAddress, computer.IPAddress));
                context.SaveChanges();

                c = await context.Computers!.Where(c => c.MacAddress == computer.MacAddress).FirstAsync();

                Computer output = new Computer(c.MacAddress, c.IPAddress, c.Status, c.Name);
                output.id = c.id;

                return (output.id, null);
            }
            else
            {
                c.IPAddress = computer.IPAddress;
                context.SaveChanges();

                Computer output = new Computer(c.MacAddress, c.IPAddress, c.Status, c.Name);
                output.id = c.id;

                if (context.Tasks == null)
                    return (output.id, null);

                try
                {
                    List<TaskResult>? configs = new List<TaskResult>();

                    await context.Tasks!.Where(t => t.idPC == c.id).ToListAsync().ContinueWith(t =>
                    {
                        foreach (Tasks task in t.Result)
                        {
                            configs.Add(new TaskResult(task.idConfig));
                        }
                    });

                    return (output.id, configs);
                }
                catch (Exception) { }

                return (output.id, null);
            }
        }

        public bool IsValidIP(string ipAddress)
        {
            string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
            return Regex.IsMatch(ipAddress, pattern);
        }
        public bool IsValidStatus(char? c)
        {
            return c == 't' || c == 'f' || c == 'q';
        }
        public bool IsValidMac(string macAddress)
        {
            string pattern = @"^[0-9a-fA-F]{12}$";
            return Regex.IsMatch(macAddress, pattern);
        }
    }
}
