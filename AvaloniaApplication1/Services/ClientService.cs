using AvaloniaApplication1.Data;
using AvaloniaApplication1.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Services;

public class ClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> AddClientAsync(
        string firstName,
        string lastName,
        string email)
    {
        var client = new Client
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            CreatedAt = DateTime.Now
        };

        _context.Clients.Add(client);

        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<int> GetClientCountAsync()
    {
        return await _context.Clients.CountAsync();
    }
}