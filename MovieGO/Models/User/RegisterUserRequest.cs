using System.ComponentModel.DataAnnotations;

namespace MovieGO.Models.User
{
    public record RegisterUserRequest(
       [Required] string Username,
       [Required] string Password,
       [Required] string Email);
}
