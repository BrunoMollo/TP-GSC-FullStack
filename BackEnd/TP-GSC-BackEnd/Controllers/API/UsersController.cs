using Microsoft.AspNetCore.Authorization;
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

            if (user.UserName != "Bruno" || user.Password != "123")
                return NotFound("Icorrect User or password");


            var bearer = JwtHandler.GenerateToken(user);

            return Ok(new { token = bearer });
        }

            
        [HttpGet("checkToken")]
        [Authorize]
        public IActionResult checkJwtToken() {
            return Ok( new { isValid = true } ) ;
        }


    }



}
