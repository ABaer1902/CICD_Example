using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.ViewModels;
using System;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    // isntance of the ClientService class to handle database operations
    private readonly ClientService _clientService;

    public MainWindow()
    {
        InitializeComponent();

        var context = new AppDbContext();
        _clientService = new ClientService(context);

        //throw new InvalidOperationException("Intentional runtime failure for CI/CD demo.");
    }

    private async void AddEntry_Click(object? sender, RoutedEventArgs e)        // Add an Entry to the database when button is clicked
    {
        await _clientService.AddClientAsync(
            "John",
            "Smith",
            "john@example.com");

        ResultText.Text = "Client added successfully.";
    }
    private async void QueryDatabase_Click(object? sender, RoutedEventArgs e)   // Querie the database for the number of clients when button is clicked
    {
        var count = await _clientService.GetClientCountAsync();

        // Update text on result screen
        ResultText.Text = $"There are {count} clients in the database.";

        // Update the number of entries in the ViewModel
        if (this.DataContext is MainViewModel vm)
        {
            vm.nEntries = count;  
        }
    }
}