using Microsoft.EntityFrameworkCore;

namespace BasicApi.Data;

public class BasicDataContext : DbContext
{
    public BasicDataContext(DbContextOptions<BasicDataContext> options): base(options)
    {

    }

    public DbSet<Agent>? Agents { get; set; }
}
