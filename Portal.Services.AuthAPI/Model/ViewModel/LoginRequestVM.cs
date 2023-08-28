namespace Portal.Services.AuthAPI.Model.ViewModel;

public class LoginRequestVM
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
