﻿namespace Portal.Services.AuthAPI.Model.ViewModel;

public class UserVM
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public List<string>? Roles { get; set; }
}
