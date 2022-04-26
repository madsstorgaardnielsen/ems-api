using AutoMapper;
using ems_api.Configurations;
using ems_api.Database.IRepository;
using ems_api.Models;
using ems_api.Models.DAOs;
using ems_api.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    [Authorize]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteUser(string id) {
        var user = await _unitOfWork.Users.Get(u => u.Id == id);
        if (user == null) {
            return BadRequest();
        }

        await _unitOfWork.Users.Delete(id);
        await _unitOfWork.Save();

        return NoContent();
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDTO userDto) {
        if (!ModelState.IsValid) {
            _logger.LogError($"Error validating data in {nameof(UpdateUser)}");
            return BadRequest(ModelState);
        }

        var user = await _unitOfWork.Users.Get(u => u.Id == id);
        if (user == null) {
            return BadRequest("Invalid data");
        }

        user.UserName = userDto.Email;
        user.NormalizedEmail = userDto.Email.ToUpper();
        user.NormalizedUserName = userDto.Email.ToUpper();

        _mapper.Map(userDto, user);
        _unitOfWork.Users.Update(user);
        await _unitOfWork.Save();

        return NoContent();
    }

    [Authorize]
    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto) {
        if (!ModelState.IsValid) {
            _logger.LogInformation($"Invalid POST in {nameof(CreateUser)}");
            return BadRequest(ModelState);
        }

        var user = _mapper.Map<User>(userDto);

        var hasher = new PasswordHasher<User>();
        var passHash = hasher.HashPassword(user, userDto.Password);
        user.PasswordHash = passHash;
        user.UserName = userDto.Email;

        await _unitOfWork.Users.Insert(user);
        await _unitOfWork.Save();
        var userDao = _mapper.Map<UserDAO>(user);
        return CreatedAtRoute("GetUser", new {id = user.Id}, userDao);
    }

    [Authorize]
    [HttpGet("users/{id}", Name = "GetUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUser(string id) {
        // var user = await _unitOfWork.Users.Get(u => u.Id == id, new List<string>{"Workdays"});
        var user = await _unitOfWork.Users.Get(u => u.Id == id);
        var result = _mapper.Map<UserDAO>(user);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUsers([FromQuery] HttpRequestParams httpRequestParams) {
        var users = await _unitOfWork.Users.GetAll(httpRequestParams);
        var results = _mapper.Map<IList<UserDAO>>(users);
        return Ok(results);
    }

    [Authorize]
    [HttpGet("users/paging")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUsers() {
        var users = await _unitOfWork.Users.GetAll();
        var results = _mapper.Map<IList<UserDAO>>(users);
        return Ok(results);
    }
}