﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace Server;

public class MyContext : DbContext
{
    public DbSet<Admin>? Admins { get; set; }
    public DbSet<Computer>? Computers { get; set; }
    public DbSet<Tasks>? Tasks { get; set; }
    public DbSet<Report>? Reports { get; set; }
    public DbSet<Config>? Configs { get; set; }
    public DbSet<Source>? Sources { get; set; }
    public DbSet<Destination>? Destinations { get; set; }
    public DbSet<Group>? Groups { get; set; }
    public DbSet<PcGroups>? PcGroups { get; set; }
    public DbSet<Snapshots>? Snapshots { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3b1_veseckylukas_db1;user=veseckylukas;password=123456;SslMode=none");
    }
}