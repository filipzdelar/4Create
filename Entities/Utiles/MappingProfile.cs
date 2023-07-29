using _4Create.Entities.Dtos;
using _4Create.Entities.Models;
using AutoMapper;

namespace _4Create.Entities.Utiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
