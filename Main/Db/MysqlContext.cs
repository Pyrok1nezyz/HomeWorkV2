using HomeWork.Classes;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Db;

public sealed class MysqlContext : DbContext
{
    public MysqlContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Computer> Computers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=usersdb;",
            new MySqlServerVersion(ServerVersion.AutoDetect("server=localhost;user=root;password=root;database=usersdb;")));
        optionsBuilder.LogTo(Console.WriteLine);
    }
}