using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Dto.UserDto;
using TP_GSC_BackEnd.Handlers;

namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJwtHandler JwtHandler;

        public UsersController(IJwtHandler jwtHandler)
        {
            JwtHandler = jwtHandler;
        }


        [HttpPost("login")]
        public IActionResult login(LoginUserDto user) {
           
            var roles = user.UserName == "admin" ?
                    new List<string> { "Admin" } :
                    new List<string> { "User" };

            var bearer = JwtHandler.GenerateToken(user, roles);

            return Ok(new { token = bearer });
        }


    }



}
