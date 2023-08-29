using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portal.Services.AuthAPI.Model;
using Portal.Services.AuthAPI.Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portal.Services.AuthAPI.Service;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;

    public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;   
    }

    public string GenerateToken(ApplicationUser applicationUser)
    {
        JwtSecurityTokenHandler tokenHandler = new();

        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, applicationUser.UserName),
            new Claim(JwtRegisteredClaimNames.Name, applicationUser.Name),
            new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
            new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id)
        };

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            IssuedAt = DateTime.Now,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
