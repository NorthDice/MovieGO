using MovieGO.Models.UserData;

namespace MovieGO.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
