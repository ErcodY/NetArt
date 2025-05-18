using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using netart.Models;

namespace netart.Services;

public class TokenService(IConfiguration config, AppSettingService settingService)
{

    public string GenerateToken(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settingService.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
        var token = new JwtSecurityToken(
            issuer: settingService.Issuer,
            audience: settingService.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}