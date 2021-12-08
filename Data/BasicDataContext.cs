using Microsoft.EntityFrameworkCore;

namespace BasicApi.Data;

public class BasicDataContext : DbContext
{
    public BasicDataContext(DbContextOptions<BasicDataContext> options): base(options)
    {

    }

    public DbSet<Agent>? Agents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>()
            .Property(p => p.LastName).HasMaxLength(50);
        modelBuilder.Entity<Agent>()
            .Property(p => p.FirstName).HasMaxLength(50);
    }
}
