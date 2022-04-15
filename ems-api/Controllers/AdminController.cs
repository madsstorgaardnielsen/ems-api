using ems_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Controllers;

//TODO CRUD operationer på employees
//TODO udtræk af timer til excel evt
//TODO logging i database? udtræk af logs?

//login json web token
//https://www.youtube.com/watch?v=v7q3pEK1EA0

//web api
//https://www.youtube.com/watch?v=Fbf_ua2t6v4

[ApiController]
// [Route("[admin]")]
[Route("/admin")]
public class AdminController : ControllerBase {
    private readonly AdminService _adminService = new();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Employee CreateEmployee(Employee employee) {
        return _adminService.Create(employee);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public List<Employee> GetAllEmployees() {
        return _adminService.Employees();
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> DeleteEmployee(int id) {
        var result =  _adminService.Delete(id);
        return result == null ? NotFound() : StatusCode(StatusCodes.Status202Accepted);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> UpdateEmployee(Employee employee) {
        var result = _adminService.Update(employee);
        return result == null ? NotFound() : StatusCode(StatusCodes.Status200OK);
    }
    
}