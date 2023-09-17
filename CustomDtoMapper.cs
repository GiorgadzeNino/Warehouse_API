using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto;

namespace BTUProject.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            //CreateMap<Person, PersonDto>().ReverseMap();
            //CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<Vacancy, VacancyDto>().ReverseMap();
            //CreateMap<Vacancy, GetVacancyDto>().ReverseMap();
            //CreateMap<VacancyPerson, VacancyPersonDto>().ReverseMap();
        }
    }
}
