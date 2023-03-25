using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models;

[Table("tbTasks")]
public class Tasks : IModel
{
    public int Id { get; set; }
    public int IdPc { get; set; }
    public int IdConfig { get; set; }

    public Tasks(int idPc, int idConfig)
    {
        IdPc = idPc;
        IdConfig = idConfig;
    }
}