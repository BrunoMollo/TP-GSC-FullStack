using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(User user);

    }
}
