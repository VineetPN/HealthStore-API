using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace HealthStore.API.Repository;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration _config;
    public TokenRepository(IConfiguration config)
    {
        _config = config;
    }
    public string CreateJWTToken(IdentityUser userName, List<string> roles)
    {
        try{
            //Create claims 
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, userName.Email));

            foreach(var role in roles){
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token) ?? string.Empty;
        }
        catch(Exception ex){
            return string.Empty;
        }
    }
}