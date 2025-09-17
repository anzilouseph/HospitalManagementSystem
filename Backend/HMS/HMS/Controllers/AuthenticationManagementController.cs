using HMS.DTO;
using HMS.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/AuthenticationManagementController")]
    [ApiController]
    public class AuthenticationManagementController : ControllerBase
    {
        private readonly IAuthenticationManagementRepo _repo;

        public AuthenticationManagementController(IAuthenticationManagementRepo repo)
        {
            _repo = repo;
        }

        //for login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var apiResponse = await _repo.LogIn(loginDto);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
