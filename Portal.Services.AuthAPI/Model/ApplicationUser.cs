using Microsoft.AspNetCore.Identity;

namespace Portal.Services.AuthAPI.Model;

public class ApplicationUser : IdentityUser
{
    public required string Name { get; set; }
}
