using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Customer;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppSevice _Service;
        public CustomerController(ICustomerAppSevice service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IResponse<List<CustomerWithIdDto>>> GetCustomersList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize)
        {
            var result = _Service.GetCustomersList(genderId, personalNumber, email, cityId, pageNumber, pageSize);
            return await result;
        }

        [HttpGet]
        public async Task<IResponse<CustomerDto>> GetCustomerDetailes(long id)
        {
            var result = _Service.GetCustomerDetails(id);
            return await result;
        }

        [HttpPost]
        public async Task<IResponse<bool>> CreateCustomer([FromBody] CustomerDto input)
        {
            var result = _Service.CreateCustomer(input);
            return await result;
        }

        [HttpPut]
        public async Task<IResponse<bool>> UpdateCustomer([FromBody] CustomerWithIdDto input)
        {
            var result = _Service.UpdateCustomer(input);
            return await result;
        }

        [HttpDelete]
        public async Task<IResponse<int>> DeleteCustomer([FromQuery] long id)
        {
            var result = _Service.DeleteCustomer(id);
            return await result;
        }


    }
}
