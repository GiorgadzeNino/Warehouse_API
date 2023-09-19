
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


        public async Task<IResponse<OrderDetailsDto>> GetOrdersDetails(int id)
        {
            var orderItem = _db.OrderItems.FirstOrDefault(x => x.ProductId == id && !x.IsDeleted);
            if (orderItem == null)
            {
                // Handle the case where the customer with the given id doesn't exist
                return new ResponseModel<OrderDetailsDto> { Error = "Orders not found", Data = null };
            }

            var orderItemDto = _mapper.Map<OrderDetailsDto>(orderItem);
            var realizationPrice = orderItem.Product.WareHouse.FirstOrDefault(x => x.ProductId == orderItem.ProductId).RealizationPrice;
            orderItemDto.Value = (realizationPrice - orderItem.DiscountPrice) * orderItem.Quantity;

            return new ResponseModel<OrderDetailsDto> { Data = orderItemDto };
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

