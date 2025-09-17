using HMS.DTO;
using HMS.Utility;

namespace HMS.IRepo
{
    public interface IEmployeeManagementRepo
    {
        public Task<ApiHelper<bool>> EmployeeRegister(EmployeeForCreationDto employee);

        //public Task<ApiHelper<List<EmployeeListDto>>> GetAllEmployee();

        public Task<ApiHelper<EmployeeListDto>> GetOwnProfile(Guid id);

    }
}
