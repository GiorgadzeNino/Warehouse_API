using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Interfaces
{
    public interface IProductsAppSevice
    {
        //Task<BTUProject.DataAccess.IResponse<bool>> Register(PersonDto input);
        //Task<BTUProject.DataAccess.IResponse<string>> Login(LoginDto input);
        //Task<IResponse<List<ProductsWithIdDto>>> GetProductsList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize);
        Task<IResponse<ProductDetailsDto>> GetProductDetails(long id);
        Task<IResponse<bool>> CreateProduct(ProductsDto input);
        Task<IResponse<bool>> UpdateProduct(ProductsWithIdDto input);
        Task<IResponse<int>> DeleteProduct(long id);

        //Task<BTUProject.DataAccess.IResponse<bool>> Update(PersonDto input);

    }
}
