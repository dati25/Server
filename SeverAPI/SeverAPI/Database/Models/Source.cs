﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models;

[Table("tbSources")]
public class Source : IModel
{
    public int Id { get; set; }
    public int? IdConfig { get; set; }
    public string Path { get; set; }

    public Source(int? idConfig, string path)
    {
        IdConfig = idConfig;
        Path = path;
    }
}