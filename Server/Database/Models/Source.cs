using Server.Results.SourceResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Database.Models;

[Table("tbSources")]
public class Source : IModel, ISource
{
    [JsonIgnore] public int Id { get; set; }
    [JsonIgnore] public int IdConfig { get; set; }
    public string Path { get; set; }

    public Source(int idConfig, string path)
    {
        IdConfig = idConfig;
        Path = path;
    }
}