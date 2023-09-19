using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Customer;
using BTUProject.Dto.Orders;
using BTUProject.Dto.Products;

namespace BTUProject.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerWithIdDto>().ReverseMap();
            CreateMap<Product, ProductsDto>().ReverseMap();
            CreateMap<Product, ProductsWithIdDto>().ReverseMap();
            CreateMap<Product, ProductDetailsDto>().ReverseMap();
            CreateMap<AddProductToWarehouseDto, WareHouse>().ReverseMap();
            CreateMap<ProductsWithIdDto, WareHouse>().ReverseMap();
            CreateMap<MakeRelationshipWithIdDto,CustomersRelationships>().ReverseMap();
            CreateMap<Orders, OrderDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemDto>().ReverseMap();

        }
    }
}
