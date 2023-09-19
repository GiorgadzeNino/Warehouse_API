using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Products;
using BTUProject.Interfaces;
using Lennt.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsAppSevice _Service;
        public ProductsController(IProductsAppSevice service)
        {
            _Service = service;
        }

        //[HttpGet]
        //public async Task<IResponse<List<ProductsWithIdDto>>> GetProductsList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize)
        //{
        //    var result = _Service.GetProductsList(genderId, personalNumber, email, cityId, pageNumber, pageSize);
        //    return await result;
        //}

        [HttpGet]
        public async Task<IResponse<ProductDetailsDto>> GetProductDetails(long id)
        {
            var result = _Service.GetProductDetails(id);
            return await result;
        }

        [HttpPost]
        public async Task<IResponse<bool>> CreateProduct([FromBody] ProductsDto input)
        {
            var result = _Service.CreateProduct(input);
            return await result;
        }

        [HttpPut]
        public async Task<IResponse<bool>> UpdateProduct([FromBody] ProductsWithIdDto input)
        {
            var result = _Service.UpdateProduct(input);
            return await result;
        }

        [HttpDelete]
        public async Task<IResponse<int>> DeleteProduct([FromQuery] long id)
        {
            var result = _Service.DeleteProduct(id);
            return await result;
        }


    }
}
