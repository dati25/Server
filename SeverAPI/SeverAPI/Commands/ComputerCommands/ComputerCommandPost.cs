using Microsoft.EntityFrameworkCore;
using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPost : ICommand
    {
        public async Task<(Computer?, int?)> Execute(ComputerResultPost computer)
        {
            if (!(IsValidIP(computer.IPAddress)) || !(IsValidMac(computer.MacAddress)))
                return (null, null);

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

                Computer output = new Computer(c.MacAddress, c.IPAddress, c.Name, c.Status);
                output.id = c.id;

                return (output, null);
            }
            else
            {
                c.IPAddress = computer.IPAddress;
                context.SaveChanges();

                Computer output = new Computer(c.MacAddress, c.IPAddress, c.Name, c.Status);
                output.id = c.id;

                int? idConfig = null;

                try
                {
                    if (context.Tasks == null) return (output, idConfig);

                    Tasks task = await context.Tasks!.Where(t => t.idPC == c.id).FirstAsync();
                    idConfig = task.idConfig;
                }
                catch (Exception) { }

                return (output, idConfig);
            }
        }

        public bool IsValidIP(string ipAddress)
        {
            string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
            return Regex.IsMatch(ipAddress, pattern);
        }

        public bool IsValidMac(string macAddress)
        {
            string pattern = @"^[0-9a-fA-F]{12}$";
            return Regex.IsMatch(macAddress, pattern);
        }
    }
}
