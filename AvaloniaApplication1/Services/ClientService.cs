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
    public async Task<List<Client>> GetClientsAsync()
    {
        using var db = new AppDbContext();

        return await db.Clients
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task<Client> AddClientAsync(
        string firstName,
        string lastName,
        string email)
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
    public async Task<int> GetClientCountAsync()
    {
        using var db = new AppDbContext();

        return await db.Clients.CountAsync();
    }
}