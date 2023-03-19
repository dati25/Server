using Microsoft.EntityFrameworkCore;
using SeverAPI.Database.Models;

namespace SeverAPI
{
    public class MyContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        //public DbSet<Group> Groups { get; set; }
        //public DbSet<PCGroups> PCGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3b1_veseckylukas_db2;user=veseckylukas;password=123456;SslMode=none");
        }
    }
}
