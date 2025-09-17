using HMS.DTO;
using HMS.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using HMS.Utility;


namespace HMS.Controllers
{
    [Route("api/EmployeeManagement")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeManagementRepo _repo;
        private readonly IAuthenticationManagementRepo _authRepo;

        public EmployeeManagementController(IEmployeeManagementRepo repo,IAuthenticationManagementRepo authenticationManaagementRepo)
        {
            _repo = repo;
            _authRepo = authenticationManaagementRepo;
        }

        //for employee Creation
        [HttpPost]
        [Authorize]
        [Route("employee-creation")]
        public async Task<IActionResult> EmployeeCreate (EmployeeForCreationDto employee)
        {
            try
            {
                var roleIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if(roleIdClaim == null || !Guid.TryParse(roleIdClaim.Value ,out var roleId))
                {
                    return Unauthorized(ApiHelper<String>.Error("Unable to generate JWT"));
                }
                //var roleChecking = await _repo.Login
                var apiResposne = await _repo.EmployeeRegister(employee);
                return Ok(apiResposne);
            }
            catch (Exception ex)
            {
                return StatusCode(500,new {message =  ex.Message}); 
            }

        }

        //for get own data
        [Authorize]
        [HttpGet]
        [Route ("get-own-profile")]
        public async Task<IActionResult> GetOwnProfile()
        {
            try
            {
                var employeeIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub);
                if (employeeIdClaim == null || !Guid.TryParse(employeeIdClaim.Value, out var employeeId))
                {
                    return Unauthorized(ApiHelper<String>.Error("Unable to generate JWT"));
                }
                var apiResposne = await _repo.GetOwnProfile(employeeId);
                return Ok(apiResposne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }
    }
}
