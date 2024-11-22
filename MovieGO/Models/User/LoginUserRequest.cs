using System.ComponentModel.DataAnnotations;

namespace MovieGO.Models.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
