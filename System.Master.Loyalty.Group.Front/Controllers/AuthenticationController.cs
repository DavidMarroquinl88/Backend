using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Authentication;
using System.Master.Loyalty.Group.Entities.Authentication;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationBussiness authService;

        public AuthenticationController(IAuthenticationBussiness authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            var result = await authService.Register(request);

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var result = await authService.Login(request);

            return Ok(result);
        }
    }
}
