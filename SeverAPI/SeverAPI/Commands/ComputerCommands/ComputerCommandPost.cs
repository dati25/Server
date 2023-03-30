using Microsoft.EntityFrameworkCore;
using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;
using SeverAPI.Results.TaskResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands;

public class ComputerCommandPost : ICommand
{
    public Computer Execute(ComputerResultPost computerPost)
    {
        ComputerTestCommands tests = new ComputerTestCommands();
        Computer computer = new Computer(computerPost.MacAddress, computerPost.IpAddress, computerPost.Name, computerPost.Status);

        tests.CheckAll(computer);

        this.context.Add(computer);
        context.SaveChanges();

        

        return computer;
    }


}