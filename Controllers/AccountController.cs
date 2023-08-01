using AutoMapper;
using chores_backend.DTOs;
using chores_backend.Models;
using chores_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ILogger<AccountController> _logger;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;

    public AccountController(UserManager<User> userManager,
        ILogger<AccountController> logger,
        IMapper mapper,
        IAuthManager authManager)
    {
        _userManager = userManager;
        _logger = logger;
        _mapper = mapper;
        _authManager = authManager;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        _logger.LogInformation($"Registration attempt for {dto.Username}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = _mapper.Map<User>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, dto.Roles);
            return Accepted();
        }
        catch (Exception e)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user != null) await _userManager.DeleteAsync(user);
            _logger.LogError(e, $"Something went wrong in the {nameof(Register)}");
            return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
        }
    }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        _logger.LogInformation($"Login attempt for {dto.Username}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (!await _authManager.ValidateUser(dto))
            {
                return Unauthorized();
            }

            return Accepted(new { Token = await _authManager.CreateToken() });
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Something went wrong in the {nameof(Login)}");
            return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
        }
    }

    /*[HttpGet("{id}")]
    [Route("profile")]
    public async Task<IActionResult> Profile(int id)
    {
        _logger.LogInformation($"Attempt to get profile information for user with id: {id}");
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return BadRequest("User is not found");
        }

        return Ok(user);
    }*/
}