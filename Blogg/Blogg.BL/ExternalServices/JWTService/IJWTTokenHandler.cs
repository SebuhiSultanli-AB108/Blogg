using Blogg.Core.Entities;

namespace Blogg.BL.ExternalServices.JWTService;

public interface IJWTTokenHandler
{
    string CreateToken(User user, int hours);
}
