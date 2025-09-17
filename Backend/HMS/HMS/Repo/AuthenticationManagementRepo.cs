using AutoMapper;
using HMS.Context;
using HMS.DTO;
using HMS.Entity;
using HMS.IRepo;
using HMS.Utility;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repo
{
    public class AuthenticationManagementRepo : IAuthenticationManagementRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthenticationManagementRepo(AppDbContext context, IConfiguration config,IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        public async Task<ApiHelper<string>> LogIn(LoginDto log)
        {
            var existingData = _context.Logins.Where(x => !x.IsDeleted && x.Email.ToLower() == log.Email.ToLower()).FirstOrDefault();
            if (existingData == null)
            {
                return ApiHelper<string>.Error("Invalid Email");
            }
            var passVerification = Utility.PasswordHashHelper.VerifyPassword(log.Password, existingData.Password, existingData.Salt);
            if (!passVerification)
            {
                return ApiHelper<string>.Error("Invalid password");
            }

            var userData = await _context.Employees.Where(x => !x.IsDeleted && x.Email.ToLower() == log.Email.ToLower()).FirstOrDefaultAsync();

            var tokenPassing = new TokenDto
            {
                RoleId = existingData.RoleId,
                UserId = userData.EmployeeId,
            };
            var tokenGenerate = new GenerateJWT(_config);
            var accessToken = tokenGenerate.GenerateToken(tokenPassing);
            //var access = Utility.GenerateJWT.GenerateToken(newLog);
            if(string.IsNullOrEmpty(accessToken))
            {
                return ApiHelper<string>.Error("Unable to generate JWT");
            }

            return ApiHelper<string>.Success(accessToken,"success");
        }

        //for role check
        public async Task<ApiHelper<string>> RoleCheck(Guid roleId)
        {
            // First try to parse the string as GUID
            //if (!Guid.TryParse(roleId, out var roleGuid))
            //{
            //    return ApiHelper<string>.Error("Invalid Role ID format");
            //}
             var role = await _context.CoreRoles
                   .Where(x => x.RoleId == roleId && !x.IsDeleted)
                   .Select(x => x.RoleName)
                   .FirstOrDefaultAsync();
            if (role == null)
            {
                return ApiHelper<string>.Error("No Role for the employee");
            }
            return ApiHelper<string>.Success(role, "succcess");

        }

    }
}
