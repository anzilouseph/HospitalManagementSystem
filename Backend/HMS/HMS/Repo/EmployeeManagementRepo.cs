using System.Xml.Linq;
using AutoMapper;
using HMS.Context;
using HMS.DTO;
using HMS.Entity;
using HMS.IRepo;
using HMS.Utility;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repo
{
    public class EmployeeManagementRepo : IEmployeeManagementRepo
    {
        public readonly AppDbContext _repo;
        public readonly IMapper _mapper;

        public EmployeeManagementRepo(AppDbContext repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //for employee creation
        public async Task<ApiHelper<bool>> EmployeeRegister(EmployeeForCreationDto employee)
        {
            await  _repo.CreateTransactionAsync();

            var logCredentials = new Login();
            logCredentials.Email = employee.Email;
            logCredentials.RoleId = employee.RoleId;

            var hashedPassword = Utility.PasswordHashHelper.HashPassword(employee.Password, out string salt);

            logCredentials.Password = hashedPassword;
            logCredentials.Salt = salt;
            await _repo.Logins.AddAsync(logCredentials);
            var rowAffected1 = await _repo.SaveChangesAsync();
            if (rowAffected1 <= 0)
            {
                return ApiHelper<bool>.Error("Doctor Created successfully");
            }

            var newEmployee = new Employee();
            newEmployee = _mapper.Map<Employee>(employee);
            await  _repo.Employees.AddAsync(newEmployee);
             var rowAffected  = await _repo.SaveChangesAsync();
            await _repo.CommitTransactionAsync();
            if (rowAffected>0)
            {
                return ApiHelper<bool>.Success(true, "Employee Created successfully");
            }
            else
            {
                return ApiHelper<bool>.Error( "Isuue with addidng new employee");

            }
        }

        //for get all employees
        //public async Task<ApiHelper<List<EmployeeListDto>>> GetAllEmployee()
        //{

        //}

        //for get own profile
        public async Task<ApiHelper<EmployeeListDto>> GetOwnProfile(Guid id)
        {
            if(id==Guid.Empty)
            {
                return  ApiHelper<EmployeeListDto>.Error("Invalid Id Exception");
            }
            
            var employee = await _repo.Employees.Where(x => !x.IsDeleted && x.EmployeeId == id).FirstOrDefaultAsync();
            if(employee==null)
            {
                return ApiHelper<EmployeeListDto>.Error("No Employee");
            }
            var employeeLog =await  _repo.Logins.Where(x => x.Email.ToLower() == employee.Email.ToLower()).FirstOrDefaultAsync();
            var employeeRole = _repo.CoreRoles.Where(x => !x.IsDeleted && x.RoleId == employeeLog.RoleId).FirstOrDefault();  
            var mapped = _mapper.Map<EmployeeListDto>(employee);
            mapped.RoleName = employeeRole.RoleName;

            return ApiHelper<EmployeeListDto>.Success(mapped, "SUCCESS");

        }


    }
}
