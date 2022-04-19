namespace ems_api.Controllers;

using Database.Enums;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//TODO get arbejdsdage, etc
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase {
    private readonly AdminService _adminService;

    public AdminController() {
        _adminService = new AdminService();
    }

    [HttpPost("CreateUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto) {
        int result;
        try {
            result = await _adminService.CreateUser(userDto);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        return result != -1 ? Ok("User created") : Problem();
    }

    [HttpDelete("DeleteUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDto>> DeleteUser(int userId) {
        var result = await _adminService.DeleteUser(userId);
        if (result) {
            return Ok("User with id: " + userId + " deleted");
        }

        return NotFound("User with id: " + userId + " not found");
    }

    [HttpPut("UpdateUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDto>> UpdateUser(UserDto userDto) {
        var result = await _adminService.UpdateUser(userDto);

        if (result != -1) {
            return Ok("User with id: " + result + " updated successfully");
        }

        return NotFound("User with id: " + result + " not found");
    }

    [HttpGet("GetAllUsers"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<List<UserDtoProjection>>> GetAllUsers() {
        return await _adminService.GetAllUsers();
    }

    [HttpGet("GetUserById"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDtoProjection>> GetUserById(int userId) {
        var result = await _adminService.GetUserById(userId);
        if (result != null) {
            return result;
        }

        return NotFound("User with id: " + userId + " not found");
    }
}