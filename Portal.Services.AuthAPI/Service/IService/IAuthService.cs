using Portal.Services.AuthAPI.Model.ViewModel;

namespace Portal.Services.AuthAPI.Service.IService;

public interface IAuthService
{
    Task<UserVM> Register(RegistrationVM registrationVM);
    Task<LoginResponseVM> Login(LoginRequestVM loginRequestVM);
    Task<UserVM> AssignRoles(string email, List<string> roles);
}
