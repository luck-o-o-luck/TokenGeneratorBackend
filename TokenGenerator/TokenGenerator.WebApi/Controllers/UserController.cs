using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using TokenGenerator.TokenGenerator.Domain.DTO;
using TokenGenerator.TokenGenerator.Services.Interfaces;
using TokenGenerator.TokenGeneratorDomain.DTO;

namespace TokenGenerator.TokenGenerator.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginModel user)
    {
        var result = await _userService.Login(user);

        if (result == null)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(result),
            expiration = result.ValidTo,
            email = user.Email
        });
    }

    [HttpPost("[action]")]
    public IActionResult Register([FromBody] RegisterModel user)
    {
        var result = _userService.Register(user);
        if (result == null)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult RefreshToken()
    {
        var result = _userService.RefreshToken();
        
        if (result == null)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(result),
            expiration = result.ValidTo,
        });
    }
}