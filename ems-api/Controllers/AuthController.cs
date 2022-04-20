namespace ems_api.Controllers;

using Services;
using Utils;
using Microsoft.AspNetCore.Mvc;

//TODO find ud af noget om UserManager
//TODO log out
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;

    public AuthController(IConfiguration configuration) {
        _configuration = configuration;
        _authService = new AuthService();
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequest request) {
        
        
        var user = await _authService.AuthenticateUser(request);

        if (user == null) return BadRequest("Invalid credentials");

        var tokenUtil = new TokenUtils(_configuration);
        var token = tokenUtil.CreateToken(user);
        return Ok(token);
    }
}