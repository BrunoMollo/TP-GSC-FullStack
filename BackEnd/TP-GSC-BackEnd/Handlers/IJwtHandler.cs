using TP_GSC_BackEnd.Dto.UserDto;

namespace TP_GSC_BackEnd.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(LoginUserDto user, IEnumerable<string> roles);
    }
}
