using MediaLab.Application.Dtos;
using MediaLab.Domain.Abstractions;
using MediaLab.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

using DomainUser = MediaLab.Domain.Entities.User.User;
namespace MediaLab.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> RegisterUser(UserDTO userDto)
    {

        var existEmail = await _userRepository.GetEmailAsync(userDto.Email);

        if (existEmail is not null)
        {
            return NotFound(UserErrors.EmailAlreadyExist(userDto.Email));
        }

        Result<DomainUser> user = DomainUser.Create(
            userDto.FullName,
            userDto.Email);

        await _userRepository.Add(user.Value);

        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        return Ok(users);
    }
};
