using Microsoft.EntityFrameworkCore;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Data;

public class AppDbContext : DbContext
{
	public DbSet<Client> Clients => Set<Client>();

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite("Data Source=app.db");
	}
}