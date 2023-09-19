using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Interfaces
{
    public interface IOrdersAppSevice
    {
        //Task<IResponse<CustomerDto>> GetCustomerDetails(long id);
        Task<IResponse<bool>> CreateOrder(OrderDto model);
        Task<IResponse<bool>> CreateOrderItem(OrderItemDto model);
        //Task<IResponse<int>> DeleteCustomer(long id);
        //Task<IResponse<bool>> MakeCustomerRelationShip(MakeRelationshipDto model);
        //Task<IResponse<bool>> UpdateCustomerRelationShip(MakeRelationshipWithIdDto model);
        //Task<IResponse<int>> DeleteCustomerRelationShip(int id);

    }
}
