using Microsoft.AspNetCore.SignalR;
using PracticaSockets.Models;

namespace PracticaSockets.Hubs;

public class UserHub: Hub
{
    public async Task CreateUser(string name)
    {
        var user = new User { Name = name };

        await Clients.All.SendAsync("UserCreated", user);
    }
}