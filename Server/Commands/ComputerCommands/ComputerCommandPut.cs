using Server.Database.Models;
using System.Text.RegularExpressions;

namespace Server.Commands.ComputerCommands;

public class ComputerCommandPut : ICommand
{
    public string? MacAddress { get; set; }
    public string? IpAddress { get; set; }
    public char? Status { get; set; }
    public string? Name { get; set; }

    public ComputerCommandPut(string? macAddress, string? ipAddress, char? status, string? name)
    {
        MacAddress = macAddress;
        IpAddress = ipAddress;
        Status = status;
        Name = name;
    }

    public Computer Execute(int id)
    {
        Computer? computer = context.Computers!.Find(id);
        ComputerTestCommands tests = new ComputerTestCommands();

        this.tester.CheckExistence(computer!);

        computer!.MacAddress = MacAddress ?? computer.MacAddress;
        computer.IpAddress = IpAddress ?? computer.IpAddress;
        computer.Status = Status ?? computer.Status;
        computer.Name = Name ?? computer.Name;

        tests.CheckAll(computer!);

        context.SaveChanges();
        return computer;
    }

    public bool IsValidIp(string ipAddress)
    {
        string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
        return Regex.IsMatch(ipAddress, pattern);
    }

    public bool IsValidMac(string macAddress)
    {
        string pattern = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
        return Regex.IsMatch(macAddress, pattern);
    }
}