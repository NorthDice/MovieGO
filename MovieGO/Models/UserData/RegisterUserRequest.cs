using System.ComponentModel.DataAnnotations;

namespace MovieGO.Models.Users.User
{
    public record RegisterUserRequest(
       [Required] string UserName,
       [Required] string Password,
       [Required] string Email);
}
