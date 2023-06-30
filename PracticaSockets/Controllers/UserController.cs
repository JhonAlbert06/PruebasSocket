using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PracticaSockets.Hubs;
using PracticaSockets.Models;
using PracticaSockets.Repository;

namespace PracticaSockets.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly IHubContext<UserHub> _userHubContext;

    public UserController(UserRepository userRepository, IHubContext<UserHub> userHubContext)
    {
        _userRepository = userRepository;
        _userHubContext = userHubContext;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.Name))
        {
            return BadRequest("Invalid user data");
        }

        _userRepository.Create(user);

        _userHubContext.Clients.All.SendAsync("UserCreated", user);

        return Ok("User created successfully");
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userRepository.GetAll();
        return Ok(users);
    }
}