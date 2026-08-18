using Microsoft.EntityFrameworkCore;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Data;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite("Data Source=app.db");
        }
    }
}