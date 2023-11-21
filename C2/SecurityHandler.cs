using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Server.Security;

/// <summary>
/// Provides basic security items for the server
/// </summary>
public class SecurityHandler
{
    /// <summary>
    /// Secure random number generator
    /// </summary>
    private readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    /// <summary>
    /// Key used to sign JWTs
    /// </summary>
    public readonly SymmetricSecurityKey AuthorizationSigningTokenKey;

    /// <summary>
    /// Credentials used to sign JWTs
    /// </summary>
    public readonly SigningCredentials AuthorizationSigningCredentials;

    public SecurityHandler()
    {
        AuthorizationSigningTokenKey = GenerateSymmetricKey(32);
        AuthorizationSigningCredentials = new(AuthorizationSigningTokenKey, SecurityAlgorithms.HmacSha256Signature);
    }

    /// <summary>
    /// Securely generates N random bytes
    /// </summary>
    /// <param name="length">Length of Byte[] to generate</param>
    /// <returns>Secure random bytes</returns>
    public byte[] GenerateRandomBytes(int length)
    {
        byte[] randomBytes = new byte[length];
        RandomNumberGenerator.GetBytes(randomBytes);
        return randomBytes;
    }

    private SymmetricSecurityKey GenerateSymmetricKey(int length) => new(GenerateRandomBytes(length));

    public byte[] HashPassword(string password)
    {
        byte[] passwordbytes = Encoding.ASCII.GetBytes(password);
        byte[] hashed = SHA256.HashData(passwordbytes);
        return hashed;
    }
}
