using AutoMapper;
using ems_api.Configurations;
using ems_api.Database.IRepository;
using ems_api.Models.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Controllers;

//TODO get arbejdsdage, etc
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminController> _logger;
    private readonly IMapper _mapper;

    public AdminController(IUnitOfWork unitOfWork, ILogger<AdminController> logger, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("workdays/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetWorkDaysFromUserId(string id) {
        try {
            var workdays = await _unitOfWork.Workdays.GetAll(w => w.UserId == id);
            var result = _mapper.Map<IList<WorkdayDAO>>(workdays);
            return Ok(result);
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error while trying: {nameof(GetWorkDaysFromUserId)}");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUser(string id) {
        try {
            // var user = await _unitOfWork.Users.Get(u => u.Id == id, new List<string>{"Workdays"});
            var user = await _unitOfWork.Users.Get(u => u.Id == id);
            var result = _mapper.Map<UserDAO>(user);
            return Ok(result);
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error while trying: {nameof(GetUser)}");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUsers() {
        try {
            var users = await _unitOfWork.Users.GetAll();
            var results = _mapper.Map<IList<UserDAO>>(users);
            return Ok(results);
        }
        catch (Exception ex) {
            _logger.LogError(ex, $"Error while trying: {nameof(GetUsers)}");
            return StatusCode(500, "Internal server error.");
        }


        // var result = await _adminService.GetUserById(userId);
        // if (result != null) {
        //     return result;
        // }
        //
        // return NotFound("User with id: " + userId + " not found");
    }
    //
    // [HttpPost("CreateUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    // public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto) {
    //     string result;
    //     try {
    //         result = await _adminService.CreateUser(userDto);
    //     }
    //     catch (Exception e) {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    //
    //     return result.Equals("") ? Ok("User created") : Problem();
    // }
    //
    // [HttpDelete("DeleteUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    // public async Task<ActionResult<UserDto>> DeleteUser(int userId) {
    //     var result = await _adminService.DeleteUser(userId);
    //     if (result) {
    //         return Ok("User with id: " + userId + " deleted");
    //     }
    //
    //     return NotFound("User with id: " + userId + " not found");
    // }
    //
    // [HttpPut("UpdateUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    // public async Task<ActionResult<UserDto>> UpdateUser(UserDto userDto) {
    //     var result = await _adminService.UpdateUser(userDto);
    //
    //     if (result.Equals("")) {
    //         return Ok("User with id: " + result + " updated successfully");
    //     }
    //
    //     return NotFound("User with id: " + result + " not found");
    // }
    //
    // [HttpGet("GetAllUsers"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    // public async Task<ActionResult<List<UserDAO>>> GetAllUsers() {
    //     return await _adminService.GetAllUsers();
    // }
}