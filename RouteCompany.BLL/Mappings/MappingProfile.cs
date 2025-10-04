using AutoMapper;
using RouteCompany.BLL.DTOs.EmployeeDTOs;
using RouteCompany.DAL.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Employee,AllEmployeesDTO>()
                .ForMember(dest => dest.Gender,options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType , options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));
            CreateMap<Employee,EmployeeDetailsDTO>()
                .ForMember(dest => dest.Gender,options => options.MapFrom(src=> src.Gender))
                .ForMember(dest => dest.EmployeeType,options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate , options=> options.MapFrom(src=>DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HiringDate,options => options.MapFrom(src=> src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            /*            CreateMap<Employee, EmployeeDetailsDTO>().ReverseMap();*/  // if i had a specific business that i must map the 2 sides 
            CreateMap<UpdatedEmployeeDTO, Employee>()
                .ForMember(dest=> dest.HiringDate , options => options.MapFrom(src=>src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
