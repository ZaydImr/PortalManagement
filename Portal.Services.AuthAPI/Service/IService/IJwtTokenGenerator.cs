using Portal.Services.AuthAPI.Model;

namespace Portal.Services.AuthAPI.Service.IService;

public interface IJwtTokenGenerator
{
    public string GenerateToken(ApplicationUser applicationUser);
}
