namespace SeverAPI.Results.ComputerResults;

public class ComputerResultPost
{
    public string MacAddress { get; set; }
    public string IpAddress { get; set; }
    public string? Name { get; set; }
    public char Status { get; set; }

    public ComputerResultPost(string macAddress, string ipAddress, string? name, char status = 'q')
    {
        MacAddress = macAddress;
        IpAddress = ipAddress;
        Name = name;
        Status = status;
    }
}