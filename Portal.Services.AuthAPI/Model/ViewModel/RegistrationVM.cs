namespace Portal.Services.AuthAPI.Model.ViewModel;

public class RegistrationVM
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public List<string>? Roles { get; set; }
}
