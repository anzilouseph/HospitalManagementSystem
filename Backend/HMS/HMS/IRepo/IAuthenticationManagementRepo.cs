using HMS.DTO;
using HMS.Utility;

namespace HMS.IRepo
{
    public interface IAuthenticationManagementRepo
    {
        public Task<ApiHelper<string>> LogIn(LoginDto credentials);
        public Task<ApiHelper<string>> RoleCheck(Guid roleId);
    }
}
