using Microsoft.AspNetCore.Mvc;
using Portal.Services.AuthAPI.Model.ViewModel;
using Portal.Services.AuthAPI.Service.IService;

namespace Portal.Services.AuthAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationVM registrationVM)
    {
        try
        {
            UserVM user = await _authService.Register(registrationVM);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);        
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestVM loginRequestVM)
    {
        try
        {
            LoginResponseVM loginResponseVM = await _authService.Login(loginRequestVM);
            return Ok(loginResponseVM);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AssignRoles")]
    public async Task<IActionResult> AssignRoles(UserVM User)
    {
        try
        {
            UserVM user = await _authService.AssignRoles(User.Email, User.Roles);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
