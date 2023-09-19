using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Orders;
using BTUProject.Interfaces;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersAppSevice _Service;
        public OrdersController(IOrdersAppSevice service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IResponse<OrderDetailsDto>> GetOrdersDetails(int id)
        {
            var result = _Service.GetOrdersDetails(id);
            return await result;
        }

        [HttpPost]
        public async Task<IResponse<bool>> CreateOrder([FromBody] OrderDto model)
        {
            var result = _Service.CreateOrder(model);
            return await result;
        }

        [HttpPost]
        public async Task<IResponse<bool>> CreateOrderItem([FromBody] OrderItemDto model)
        {
            var result = _Service.CreateOrderItem(model);
            return await result;
        }

        [HttpPut]
        public async Task<IResponse<bool>> AddDiscountOrder([FromBody] DiscountOrderDto model)
        {
            var result = _Service.AddDiscountOrder(model);
            return await result;
        }

        //[HttpDelete]
        //public async Task<IResponse<int>> DeleteOrders([FromQuery] long id)
        //{
        //    var result = _Service.DeleteOrders(id);
        //    return await result;
        //}

    }
}
