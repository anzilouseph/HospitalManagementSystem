using HMS.DTO;
using HMS.IRepo;
using HMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;


namespace HMS.Controllers
{
    [Route("api/AdminManagementController")]
    [ApiController]
    public class AdminManagementController : ControllerBase
    {
        private readonly IAdminManagementRepo _adminManagementRepo;

        private readonly IAuthenticationManagementRepo _authenticationManagementRepo;

        public AdminManagementController(IAdminManagementRepo adminManagementRepo,IAuthenticationManagementRepo authenticationManagementRepo)
        {
            _adminManagementRepo = adminManagementRepo;
            _authenticationManagementRepo = authenticationManagementRepo;
        }

        //FOR GET EMPLOYEE BY ID
        [HttpGet ("get-employee-by-id")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value ,out var userId))
            {
                return Unauthorized(ApiHelper<EmployeeListDto>.Error("Unable to generate JWT"));
            }
            try
            {
                var roleCheck = await _authenticationManagementRepo.RoleCheck(userId);
                if (roleCheck.data.ToLower() != "admin")
                {
                    return Unauthorized(ApiHelper<EmployeeListDto>.Error("Unable to generate JWT"));
                }
                
                    var apiResponse = await _adminManagementRepo.GetEmployeeById(employeeId);

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        //for get all employees
        [HttpGet("get-all-employees")]
        [Authorize]
        public async Task<IActionResult> GetAllEmployees()
        {
            var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
            try
            {
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))

                {
                    return Unauthorized(ApiHelper<EmployeeListDto>.Error("Unable to generate JWT"));

                }
                var role = await _authenticationManagementRepo.RoleCheck(userId);
                if (role.data.ToLower() != "admin")
                {
                    return Unauthorized("YOU ARE NOT the ADMIN");
                }
                var apiResposne = await _adminManagementRepo.GetAllEmployee();
                return Ok(apiResposne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
