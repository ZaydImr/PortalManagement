namespace Portal.Services.AuthAPI.Model.ViewModel;

public class LoginResponseVM
{
    public UserVM? User { get; set; }
    public string? Token { get; set; }
}
