
using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto.Orders;
using BTUProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTUProject.Service
{
    public class OrdersAppService : IOrdersAppSevice
    {
        private readonly WarehouseDbContext _db;
        private readonly IMapper _mapper;

        public OrdersAppService(
            WarehouseDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IResponse<OrderDetailsDto>> GetOrdersDetails(int productId)
        {
            var orderItem = _db.OrderItems.FirstOrDefault(x => x.ProductId == productId && !x.IsDeleted);
            if (orderItem == null)
            {
                // Handle the case where the customer with the given id doesn't exist
                return new ResponseModel<OrderDetailsDto> { Error = "Orders not found", Data = null };
            }
            var newOrderItem = new OrderDetailsDto();
            var orderItemDto = _mapper.Map<OrderDetailsDto>(orderItem);
            var warehouse = _db.WareHouse.FirstOrDefault(x => x.ProductId == productId && !x.IsDeleted);
            var product = _db.Product.FirstOrDefault(p => p.Id == productId);
            var realizationPrice = warehouse.RealizationPrice;
            newOrderItem.Value = (realizationPrice - orderItem.DiscountPrice) * orderItem.Quantity;
            newOrderItem.Name = product.Name;
            newOrderItem.Code = product.Code;
            newOrderItem.CategoryId = product.CategoryId;
            newOrderItem.OrderId = orderItemDto.OrderId;
            return new ResponseModel<OrderDetailsDto> { Data = newOrderItem };
        }

        public async Task<IResponse<bool>> CreateOrder(OrderDto model)
        {
            try
            {
                var order = _mapper.Map<Orders>(model);

                _db.Add(order);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the order.", Data = false };
            }
        }

        public async Task<IResponse<bool>> CreateOrderItem(OrderItemDto model)
        {
            try
            {
                var orderItem = new OrderItems
                {
                    OrderId = model.OrderId,
                    ProductId = model.ProductId,
                    UnitPrice = model.UnitPrice,
                    Quantity = model.Quantity,
                    IsDiscounted = model.IsDiscounted,
                    DiscountPrice = model.DiscountPrice
                };

                _db.Add(orderItem);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the order item.", Data = false };
            }
        }

        public async Task<IResponse<bool>> AddDiscountOrder(DiscountOrderDto model)
        {
            try
            {
                var orderItem = _db.OrderItems.FirstOrDefault(x => x.Id == model.orderItemId && !x.IsDeleted);
                if (orderItem != null)
                {
                    orderItem.IsDiscounted = true;
                    orderItem.DiscountPrice = model.discount;
                };
                _db.Update(orderItem);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the order.", Data = false };
            }
        }

    }
}

