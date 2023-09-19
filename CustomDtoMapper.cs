using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Customer;
using BTUProject.Dto.Products;

namespace BTUProject.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            //CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerWithIdDto>().ReverseMap();
            CreateMap<Product, ProductsDto>().ReverseMap();
            CreateMap<Product, ProductsWithIdDto>().ReverseMap();
            CreateMap<Product, ProductDetailsDto>().ReverseMap();

            //CreateMap<Vacancy, GetVacancyDto>().ReverseMap();
            //CreateMap<VacancyPerson, VacancyPersonDto>().ReverseMap();
        }
    }
}
