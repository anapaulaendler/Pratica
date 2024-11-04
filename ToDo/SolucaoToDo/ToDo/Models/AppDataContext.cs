using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public DbSet<Activity> ActivityTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BancoDeDados.db");
    }

}