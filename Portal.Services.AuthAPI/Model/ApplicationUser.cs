using Microsoft.AspNetCore.Identity;

namespace Portal.Services.AuthAPI.Model;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
}
