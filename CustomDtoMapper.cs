using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Customer;

namespace BTUProject.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            //CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerWithIdDto>().ReverseMap();
            //CreateMap<Vacancy, VacancyDto>().ReverseMap();
            //CreateMap<Vacancy, GetVacancyDto>().ReverseMap();
            //CreateMap<VacancyPerson, VacancyPersonDto>().ReverseMap();
        }
    }
}
