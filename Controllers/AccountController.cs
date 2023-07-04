using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public AccountController()
    {
        
    }
}