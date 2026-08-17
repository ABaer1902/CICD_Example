using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Services;
using System;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    // isntance of the ClientService class to handle database operations
    private readonly ClientService _clientService = new();

    public MainWindow()
    {
        InitializeComponent();
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

        ResultText.Text = $"There are {count} clients in the database.";
    }
}