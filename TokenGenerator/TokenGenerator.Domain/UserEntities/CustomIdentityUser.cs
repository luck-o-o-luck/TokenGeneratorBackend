using System.ComponentModel.DataAnnotations;

namespace TokenGenerator.TokenGenerator.Domain.UserEntities;

public class CustomIdentityUser
{
    public Guid Id { get; init; }
    [Key] 
    public string Email { get; set; }
    public string Password { get; set; }
}