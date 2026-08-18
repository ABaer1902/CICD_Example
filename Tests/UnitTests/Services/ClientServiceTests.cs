using AvaloniaApplication1.Services;
using Xunit;

namespace UnitTests.Services;

public class ClientServiceTests
{
    // Test to validate that addClient Creates a tuple entry in the database
    [Fact]
    public async Task Validate_AddClient()
    {
        var service = new ClientService();

        var oldCount = await service.GetClientCountAsync();
        var result = await service.AddClientAsync("Test", "Smith", "Test.smith@example.com", DateTime.Now);
        var newCount = await service.GetClientCountAsync();

        Assert.Equal(oldCount + 1, newCount);
    }
}