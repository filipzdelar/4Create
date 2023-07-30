using _4Create.Entities.Dtos;
using _4Create.Entities.Models;
using AutoMapper;

namespace _4Create.Entities.Utiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().PreserveReferences();
            CreateMap<CompanyDto, Company>().ForMember(dest => dest.Employees, opt => opt.Ignore()); ;


            CreateMap<Employee, EmployeeDto>().PreserveReferences();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<EmployeeToCreateDto, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
