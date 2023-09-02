using HomeWork.Classes;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Db;

public sealed class MySQLDbContext : DbContext
{
        public MySQLDbContext()
        {
            Database.EnsureCreated();
        }

        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Computer> Computers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=localhost;user=root;password=telega123;database=usersdb;", new MySqlServerVersion(new Version(8, 1, 0)));


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
}