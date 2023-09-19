using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto.Products;
using BTUProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTUProject.Service
{
    public class ProductsAppService : IProductsAppSevice
    {
        private readonly WarehouseDbContext _db;
        private readonly IMapper _mapper;

        public ProductsAppService(
            WarehouseDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IResponse<ProductDetailsDto>> GetProductDetails(long id)
        {
            var product = _db.Product.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (product == null)
            {
                // Handle the case where the product with the given id doesn't exist
                return new ResponseModel<ProductDetailsDto> { Error = "Products not found", Data = null };
            }

            var productDto = _mapper.Map<ProductDetailsDto>(product);

            return new ResponseModel<ProductDetailsDto> { Data = productDto };
        }

        public async Task<IResponse<bool>> AddProductInWarehouse(AddProductToWarehouseDto input)
        {
            try
            {
                var warehouse = _mapper.Map<WareHouse>(input);
                warehouse.Product.Id = input.ProductId;
                warehouse.IsDeleted = false;
                _db.Add(warehouse);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the product.", Data = false };
            }
        }

        public async Task<IResponse<bool>> CreateProduct(ProductsDto input)
        {
            try
            {
                var product = _mapper.Map<Product>(input);
                product.IsDeleted = false;
                _db.Add(product);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the product.", Data = false };
            }
        }

        public async Task<IResponse<bool>> UpdateProduct(ProductsWithIdDto input)
        {
            var customer = _db.Product.FirstOrDefault(x => x.Id == input.Id && !x.IsDeleted);
            if (customer != null)
            {
                _mapper.Map(input, customer);
            }
            _db.Update(customer);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };

        }

        public async Task<IResponse<int>> DeleteProduct(long id)
        {
            var customer = _db.Product.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (customer == null)
            {
                return new ResponseModel<int> { Error = "Product not found", Data = 0 };
            }
            customer.IsDeleted = true;
            _db.Update(customer);
            _db.SaveChanges();

            return new ResponseModel<int> { Error = null, Data = customer.Id };

        }


        //public async Task<IResponse<List<ProductsWithIdDto>>> GetProductsList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize)
        //{
        //var query = _db.Product
        //    .AsNoTracking()
        // .Where(x =>
        //     !x.IsDeleted &&
        //     (genderId != null && x.GenderId == genderId) &&
        //     (personalNumber != null && x.PersonalNumber == personalNumber) &&
        //     (email != null && x.Email == email) &&
        //     (cityId != null && x.Cities.Id == cityId))
        // .OrderBy(x => x.Id);

        //int recordsToSkip = (pageNumber - 1) * pageSize;

        //// Apply paging to the query
        //var pagedQuery = query.Skip(recordsToSkip).Take(pageSize);

        //// Execute the query and retrieve the results
        //var results = pagedQuery.ToList();

        //// Map the results to DTOs
        //var dtos = _mapper.Map<List<ProductsWithIdDto>>(results);

        //// Return the paged results
        //return new ResponseModel<List<ProductsWithIdDto>>()
        //{
        //    Data = dtos
        //};
    }

}


