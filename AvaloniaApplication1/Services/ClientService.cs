using AvaloniaApplication1.Data;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Services;

public class ClientService
{
    // Add a tuple to the database (always the ssame aside from CreatedAt)
    public async Task<Client> AddClientAsync( string firstName, string lastName, string email)
    {
        using var db = new AppDbContext();

        var client = new Client
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            CreatedAt = DateTime.Now
        };

        db.Clients.Add(client);

        await db.SaveChangesAsync();

        return client;
    }

    // Query the database for the number of clients
    public async Task<int> GetClientCountAsync()
    {
        using var db = new AppDbContext();

        return await db.Clients.CountAsync();
    }
}