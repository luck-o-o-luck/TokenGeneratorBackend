using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TokenGenerator.TokenGenerator.Domain.DTO;
using TokenGenerator.TokenGenerator.Domain.UserEntities;
using TokenGenerator.TokenGenerator.Services.Interfaces;
using TokenGenerator.TokenGeneratorDataAccess;
using TokenGenerator.TokenGeneratorDomain.DTO;

namespace TokenGenerator.TokenGenerator.Services.Implementations;

public class UserService : IUserService
{
    public async Task<Guid> Register(RegisterModel user)
    {
        await using var db = new UserDbContext();

        if (user.Password != user.ConfirmPassword)
        {
            throw new Exception("Passwords do not match");
        }

        var newUser = new CustomIdentityUser() { Id = Guid.NewGuid(), Email = user.Email, Password = user.Password };

        await db.Users.AddAsync(newUser);
        await db.SaveChangesAsync();

        return newUser.Id;
    }

    public async Task<JwtSecurityToken> Login(LoginModel user)
    {
        await using var db = new UserDbContext();

        var foundUser = await db.Users.FindAsync(user.Email);

        if (foundUser == null)
        {
            throw new Exception("User not found");
        }
        
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, foundUser.Email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30));

        return token;
    }
}