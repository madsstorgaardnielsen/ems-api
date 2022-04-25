using AutoMapper;
using ems_api.Models.DTOs;
using ems_api.Services;
using Microsoft.AspNetCore.Identity;

namespace ems_api.Controllers;

using Microsoft.AspNetCore.Mvc;

//TODO find ud af noget om UserManager
//TODO log out
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly UserManager<User> _userManager;
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;

    public AuthController(
        UserManager<User> userManager,
        ILogger<AuthController> logger,
        IMapper mapper, IAuthManager authManager) {
        _userManager = userManager;
        _logger = logger;
        _mapper = mapper;
        _authManager = authManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDto) {
        _logger.LogInformation($"Init login attempt: {loginUserDto.Email}");

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            if (await _authManager.ValidateUser(loginUserDto)) {
                return Accepted(new {Token = await _authManager.CreateToken()});
            }

            return Unauthorized();
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error in {nameof(Login)}");
            return Problem($"Error in {nameof(Login)}", statusCode: 500);
        }
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto) {
        _logger.LogInformation($"Init registration attempt: {userDto.Email}");

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userDto.Roles);
            return Accepted();
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error in {nameof(Register)}");
            return Problem($"Error in {nameof(Register)}", statusCode: 500);
        }
    }
}