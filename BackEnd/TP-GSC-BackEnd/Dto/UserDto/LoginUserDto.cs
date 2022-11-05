using Microsoft.Win32.SafeHandles;

namespace TP_GSC_BackEnd.Dto.UserDto
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool isInvalid() { 
            return UserName is null || Password is null;
        }
    }
}
