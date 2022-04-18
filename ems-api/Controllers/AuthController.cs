using ems_api.DTOs;
using ems_api.Security;
using ems_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Controllers;

//TODO log out
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration) {
        _configuration = configuration;
    }

    private readonly UserService _userService = new();

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequest request) {
        var user =  _userService.AuthenticateUser(request);

        if (user != null) {
            var tokenUtil = new TokenUtils(_configuration);
            var token = tokenUtil.CreateToken(user);
            return Ok(token);
        }

        return BadRequest("Invalid credentials");
    }

}