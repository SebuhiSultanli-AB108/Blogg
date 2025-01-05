
using Blogg.BL.DTOs.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blogg.API;

public static class ServiceRegistration
{
    public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration _configuration)
    {
        services.Configure<JWTOptions>(_configuration.GetSection(JWTOptions.Jwt));
        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration _configuration)
    {
        JWTOptions jwtopt = new JWTOptions();
        jwtopt.Issuer = _configuration.GetSection(JWTOptions.Jwt)["Issuer"]!.ToString();
        jwtopt.Audience = _configuration.GetSection(JWTOptions.Jwt)["Audience"]!.ToString();
        jwtopt.SecretKey = _configuration.GetSection(JWTOptions.Jwt)["SecretKey"]!.ToString();
        var singInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtopt.SecretKey));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey = singInKey,
                ValidAudience = jwtopt.Audience,
                ValidIssuer = jwtopt.Issuer,
                ClockSkew = TimeSpan.Zero
            };
        });
        return services;
    }
}
