using AvaloniaApplication1.ViewModels;
using Xunit;

namespace UnitTests.ViewModels;

public class MainViewModelTests
{
    [Fact]
    // Ensure nEntries is initialized to 0
    public void Validate_nEntriesInitialization()
    {
        // Instantiate window
        var viewModel = new MainViewModel();

        // Assert that nEntries is initialized to 0
        Assert.Equal(0, viewModel.nEntries);
    }
    /*
    // Test to ensure that the nEntries property updates correctly when the database is queried
    public void Validate_nEntriesUpdates()
    {
        // Instantiate window
        var viewModel = new MainViewModel();
        var view = new MainWindow();

        // compare old count with new count after querying the database
        var oldCount = viewModel.nEntries;
        var newCount = view.QueryDatabase_Click();
        Assert.NotEqual(newCount, oldCount);
    }
    */
    }