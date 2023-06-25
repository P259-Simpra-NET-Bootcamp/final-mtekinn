using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;
using SimpraFinal.Data.Entities;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        
        return Ok(users);
    }

    [AllowAnonymous]
    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult<UserDTO>> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return _mapper.Map<UserDTO>(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UserDTO userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest();
        }

        var user = _mapper.Map<User>(userDto);
        await _userService.UpdateAsync(user);

        return NoContent();
    }
    
    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(LoginDTO dto)
    {
        var user = await _userService.AuthenticateAsync(dto.Username, dto.Password);

        if (user == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(user);
    }
    
    
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        var user = _mapper.Map<User>(registerDto);
        await _userService.Register(user, registerDto.Password, registerDto.Email);
        return Ok(user);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        await _userService.DeleteAsync(id);

        return NoContent();
    }
}
