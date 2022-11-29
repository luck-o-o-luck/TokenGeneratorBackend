using System.IdentityModel.Tokens.Jwt;
using TokenGenerator.TokenGenerator.Domain.DTO;
using TokenGenerator.TokenGeneratorDomain.DTO;

namespace TokenGenerator.TokenGenerator.Services.Interfaces;

public interface IUserService
{
    Task<Guid> Register(RegisterModel user);
    Task<JwtSecurityToken> Login(LoginModel user);
    JwtSecurityToken RefreshToken();
}