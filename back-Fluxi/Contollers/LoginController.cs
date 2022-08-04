using back_Fluxi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Fluxi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _loginService;

        public LoginController(ILogin loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Post(UserDTO userDTO)
        {
            string token = _loginService.Login(userDTO);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return StatusCode(401);
            }
        }
    }
}

