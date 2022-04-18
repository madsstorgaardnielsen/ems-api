using ems_api.Database.Repositories;
using ems_api.DTOs;
using ems_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Controllers;

//TODO edit user, delete user, get user, get all users, 

//TODO auth på CRUD
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly UserService _userService = new();


    [HttpPost("AddUser")]
    public async Task<ActionResult<UserDto>> AddUser(UserDto userDto) {
        var result = _userService.AddUser(userDto);

        Console.WriteLine("result->" + result);

        return Ok(result);
    }


    // [HttpPost]
    // public ActionResult EditEmployee(Employee model) {
    //     if (ModelState.IsValid) {
    //         int result = _employeeRepository.UpdateEmployee(model);
    //     }
    // }
    //
    //
    // [HttpPost]
    // public ActionResult DeleteEmployee(Employee model) {
    //     _employeeRepository.DeleteEmployee(model.EmployeeId);
    // }
}