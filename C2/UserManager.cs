using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace C2;

public static class UserManager
{
    public static Dictionary<string, byte[]> Users = [];

    static UserManager()
    {
        Users.Add("admin", C2State.SecurityHandler.HashPassword("root"));
    }

    public static bool ValidateUser(string username, string password)
    {
        if (Users.TryGetValue(username, out byte[]? correctPassword) && correctPassword != null)
        {
            byte[] hashed = C2State.SecurityHandler.HashPassword(password);
            return correctPassword.SequenceEqual(hashed);
        }

        return false;
    }

    public static string GenerateAuthorizationToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username), // Subject (typically the user's identifier)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique token identifier
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),

            Expires = DateTime.UtcNow.Add(new TimeSpan(0, 5, 0)), // Token expiration time

            SigningCredentials = C2State.SecurityHandler.AuthorizationSigningCredentials
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
