using AvaloniaApplication1.Services;
using AvaloniaApplication1.Data;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests.Services;

public class ClientServiceTests
{
    // Test to validate that addClient Creates a tuple entry in the database
    [Fact]
    public async Task Validate_AddClient()
    {
        // Create a temporary SQLite database.
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        await using var context = new AppDbContext(options);

        // Instanciate EF Core tables.
        await context.Database.EnsureCreatedAsync();

        // Test connection
        var canConnect = await context.Database.CanConnectAsync();
        Assert.True(canConnect);

        var directCount = await context.Clients.CountAsync();
        Assert.Equal(0, directCount);


        var service = new ClientService(context);

        var oldCount = await service.GetClientCountAsync();       // -1 if no database pulled
        var result = await service.AddClientAsync("Test", "Smith", "Test.smith@example.com");
        var newCount = await service.GetClientCountAsync();       // -1 if no database pulled

        Assert.Equal(oldCount + 1, newCount);
    }
}