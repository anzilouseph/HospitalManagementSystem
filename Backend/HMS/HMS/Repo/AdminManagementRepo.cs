using AutoMapper;
using HMS.Context;
using HMS.DTO;
using HMS.IRepo;
using HMS.Utility;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repo
{
    public class AdminManagementRepo : IAdminManagementRepo
    {
        public readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdminManagementRepo(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        //for get EmployeeById
        public async Task<ApiHelper<EmployeeListDto>> GetEmployeeById(Guid employeeId)
        {
            var employees = _context.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            var  mapped = _mapper.Map<EmployeeListDto>(employees);
            if(mapped == null)
            {
                return ApiHelper<EmployeeListDto>.Error("Invalid id");
            }
            else
            {
                return ApiHelper<EmployeeListDto>.Success(mapped, "Invalid id");
            }
        }

        //for get all employees
        public async Task<ApiHelper<List<EmployeeListDto>>> GetAllEmployee()
        {
            var employee = await _context.Employees.Where(x=>!x.IsDeleted).ToListAsync();
            var mapped = new List<EmployeeListDto>();
            mapped  = _mapper.Map<List<EmployeeListDto>>(employee);
            return ApiHelper<List<EmployeeListDto>>.Success(mapped, "success");
        }


    }
}
