using Blogg.BL.DTOs.Options;
using Blogg.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blogg.BL.ExternalServices.JWTService;

public class JWTTokenHandler : IJWTTokenHandler
{
    readonly JWTOptions _options;
    public JWTTokenHandler(IOptions<JWTOptions> options)
    {
        _options = options.Value;
    }
    public string CreateToken(User user, int hours = 24)
    {
        List<Claim> claims =
            [
                new Claim("Username", user.Username),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString()),
                new Claim("Fullname", user.Name + " " + user.Surname)
            ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken securityToken = new(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddSeconds(hours),
            signingCredentials: credentials
            );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(securityToken);
    }
}
