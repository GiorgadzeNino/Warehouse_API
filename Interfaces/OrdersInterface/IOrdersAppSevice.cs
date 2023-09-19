using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Interfaces
{
    public interface IOrdersAppSevice
    {
        Task<IResponse<OrderDetailsDto>> GetOrdersDetails(int id);
        Task<IResponse<bool>> CreateOrder(OrderDto model);
        Task<IResponse<bool>> CreateOrderItem(OrderItemDto model);
        Task<IResponse<bool>> AddDiscountOrder(DiscountOrderDto model);

    }
}
