namespace Blogg.BL.DTOs.Options;

public class JWTOptions
{
    public const string Jwt = "JwtOptions";
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}