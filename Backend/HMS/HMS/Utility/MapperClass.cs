using AutoMapper;
using HMS.DTO;
using HMS.Entity;
namespace HMS.Utility
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Employee,EmployeeForCreationDto>().ReverseMap();
            CreateMap<Patient, PatientForCreationDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();  
        }
    }
}
