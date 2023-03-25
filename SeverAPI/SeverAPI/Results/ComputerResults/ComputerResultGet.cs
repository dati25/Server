using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults;

public class ComputerResultGet
{
    public int Id { get; set; }
    public string MacAddress { get; set; }
    public string IpAddress { get; set; }
    public string? Name { get; set; }
    public char Status { get; set; }

    public ComputerResultGet(Computer computer)
    {
        Id = computer.Id;
        MacAddress = computer.MacAddress;
        IpAddress = computer.IpAddress;
        Name = computer.Name;
        Status = computer.Status;
    }
}