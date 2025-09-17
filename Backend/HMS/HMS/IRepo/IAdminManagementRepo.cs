using HMS.DTO;
using HMS.Utility;

namespace HMS.IRepo
{
    public interface IAdminManagementRepo
    {
        public Task<ApiHelper<EmployeeListDto>> GetEmployeeById(Guid employeeId);
        public Task<ApiHelper<List<EmployeeListDto>>> GetAllEmployee();
    }
}
