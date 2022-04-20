using AutoMapper;
using ems_api.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ems_api.Controllers;

using Microsoft.AspNetCore.Mvc;

//https://www.youtube.com/watch?v=kCcMgxeL44I&list=PLUl9BcvgsrKYa9mUygO9lIGow-1GaNWqs&index=12
//29:21 inde

//TODO find ud af noget om UserManager
//TODO log out
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly UserManager<User> _userManager;

    // private readonly SignInManager<User> _signInManager;
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;

    public AuthController(
        UserManager<User> userManager,
        // SignInManager<User> signInManager,
        ILogger<AuthController> logger,
        IMapper mapper) {
        _userManager = userManager;
        // _signInManager = signInManager;
        _logger = logger;
        _mapper = mapper;
    }

    // [HttpPost]
    // [Route("login")]
    // public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDto) {
    //     _logger.LogInformation($"Init login attempt: {loginUserDto.Email}");
    //
    //     if (!ModelState.IsValid) {
    //         return BadRequest(ModelState);
    //     }
    //
    //     try {
    //         var result =
    //             await _signInManager.PasswordSignInAsync(loginUserDto.Email, loginUserDto.Password, false, false);
    //
    //         if (!result.Succeeded) {
    //             return Unauthorized(loginUserDto);
    //         }
    //
    //         return Accepted();
    //     }
    //     catch (Exception ex) {
    //         _logger.LogError(ex, $"Error in {nameof(Login)}");
    //         return Problem($"Error in {nameof(Login)}", statusCode: 500);
    //     }
    // }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto) {
        _logger.LogInformation($"Init registration attempt: {userDto.Email}");

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;
            
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Accepted();
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error in {nameof(Register)}");
            return Problem($"Error in {nameof(Register)}", statusCode: 500);
        }
    }


    // private readonly IConfiguration _configuration;
    // private readonly AuthService _authService;
    //
    // public AuthController(IConfiguration configuration) {
    //     _configuration = configuration;
    //     _authService = new AuthService();
    // }
    //
    // [HttpPost("login")]
    // public async Task<ActionResult<string>> Login(LoginRequest request) {
    //     
    //     
    //     var user = await _authService.AuthenticateUser(request);
    //
    //     if (user == null) return BadRequest("Invalid credentials");
    //
    //     var tokenUtil = new TokenUtils(_configuration);
    //     var token = tokenUtil.CreateToken(user);
    //     return Ok(token);
    // }
}