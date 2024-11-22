using System.ComponentModel.DataAnnotations;

namespace MovieGO.Models.Users.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
