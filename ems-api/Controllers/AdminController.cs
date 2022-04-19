using ems_api.Database.Enums;
using ems_api.DTOs;
using ems_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Controllers;

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
        var result = await _adminService.CreateUser(userDto);
        return result != -1 ? Ok("User created") : Problem();
    }

    [HttpPost("DeleteUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDto>> DeleteUser(int userId) {
        var result = await _adminService.DeleteUser(userId);
        if (result) {
            return Ok("User with id: " + userId + " deleted");
        }

        return NotFound("User with id: " + userId + " not found");
    }

    [HttpPost("UpdateUser"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDto>> UpdateUser(UserDto userDto) {
        var result = await _adminService.UpdateUser(userDto);

        if (result != -1) {
            return Ok("User with id: " + result + " updated successfully");
        }

        return NotFound("User with id: " + result + " not found");
    }

    [HttpPost("GetAllUsers"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<List<UserDtoProjection>>> GetAllUsers() {
        return await _adminService.GetAllUsers();
    }
    
    [HttpPost("GetUserById"), Authorize(Roles = $"{Role.Admin}, {Role.Moderator}")]
    public async Task<ActionResult<UserDtoProjection>> GetUserById(int userId) {
        return await _adminService.GetUserById(userId);
    }
}