using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Services.AuthAPI.Data;
using Portal.Services.AuthAPI.Model;
using Portal.Services.AuthAPI.Model.ViewModel;
using Portal.Services.AuthAPI.Service.IService;
using System.Data;

namespace Portal.Services.AuthAPI.Service;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<AuthService> _logger;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AuthService> logger, IJwtTokenGenerator jwtTokenGenerator)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponseVM> Login(LoginRequestVM loginRequestVM)
    {
        string? errMessage = String.Empty;
        try
        {
            ApplicationUser? user = await _db.User.FirstOrDefaultAsync(u => u.Email.ToLower() == loginRequestVM.Email.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestVM.Password);

            if (user == null)
            {
                errMessage = "Email incorrect !";
                throw new Exception(errMessage);
            }
            if (!isValid)
            {
                errMessage = "Password incorrect !";
                throw new Exception(errMessage);
            }

            IList<string> UserRoles = await _userManager.GetRolesAsync(user);

            UserVM userVM = new UserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Roles = UserRoles.ToList()
            };

            LoginResponseVM loginResponseVM = new LoginResponseVM
            {
                User = userVM,
                Token = _jwtTokenGenerator.GenerateToken(user)
            };

            return loginResponseVM;
        }
        catch (Exception ex)
        {
            if (errMessage.Any())
            {
                throw new Exception(errMessage);
            }
            _logger.LogError(ex.Message, ex);
            throw new Exception("Something went wrong, cannot login !");
        }
    }

    public async Task<UserVM> Register(RegistrationVM registrationVM)
    {
        ApplicationUser user = new ApplicationUser
        {
            UserName = registrationVM.UserName,
            NormalizedUserName = registrationVM.UserName?.ToLower(),
            Email = registrationVM?.Email,
            NormalizedEmail = registrationVM?.Email?.ToLower(),
            Name = registrationVM?.Name,
            PhoneNumber = registrationVM?.PhoneNumber
        };
        string? errMessage = String.Empty;

        try
        {
            IdentityResult? result = await _userManager.CreateAsync(user, registrationVM.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registrationVM.Roles);
                ApplicationUser? userToReturn = await _db.User.FirstAsync(u => u.UserName == registrationVM.UserName);
                IList<string> UserRoles = await _userManager.GetRolesAsync(userToReturn);
                UserVM userVM = new UserVM
                {
                    Id = userToReturn.Id,
                    UserName = userToReturn.UserName,
                    Email = userToReturn.Email,
                    Name = userToReturn.Name,
                    PhoneNumber = userToReturn.PhoneNumber,
                    Roles = UserRoles.ToList()
                };
                return userVM;
            }
            else
            {
                errMessage = result.Errors.Any() ? result.Errors.Select(err => err.Description).FirstOrDefault() : string.Empty;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new Exception("Something went wrong, cannot register the user !");
        }
        _logger.LogError(errMessage);
        throw new Exception(errMessage);
    }

    public async Task<UserVM> AssignRoles(string email, List<string> roles)
    {
        ApplicationUser? user = await _db.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        if (user != null)
        {
            IList<string> UserRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, UserRoles);
            await _userManager.AddToRolesAsync(user, roles);

            user = await _db.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            UserRoles = await _userManager.GetRolesAsync(user);
            return new UserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = UserRoles.ToList()
            };
        }
        throw new Exception("This email doesn't exists");
    }

}
