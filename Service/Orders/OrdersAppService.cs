
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


        //public async Task<IResponse<OrdersDto>> GetOrdersDetails(long id)
        //{
        //    var customer = _db.Orders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        //    if (customer == null)
        //    {
        //        // Handle the case where the customer with the given id doesn't exist
        //        return new ResponseModel<OrdersDto> { Error = "Orders not found", Data = null };
        //    }

        //    var customerDto = _mapper.Map<OrdersDto>(customer);

        //    return new ResponseModel<OrdersDto> { Data = customerDto };
        //}

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

        //public async Task<IResponse<bool>> UpdateOrders(OrdersWithIdDto input)
        //{
        //    try
        //    {
        //        var customer = _db.Orders.FirstOrDefault(x => x.Id == input.Id && !x.IsDeleted);
        //        if (customer != null)
        //        {
        //            _mapper.Map(input, customer);
        //        }


        //        if (DateTime.Today.AddYears(-18) < customer.BirthDate)
        //        {
        //            throw new ArgumentException("Orders must be at least 18 years old.");
        //        }


        //        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        //        // Use Regex.IsMatch to check if the email matches the pattern
        //        var emailIsValid = Regex.IsMatch(input.Email, pattern);
        //        if (!emailIsValid)
        //        {
        //            throw new ArgumentException("Invalid email address format.", nameof(input.Email));
        //        }
        //        else
        //        {
        //            _db.Update(customer);
        //            _db.SaveChanges();
        //            return new ResponseModel<bool>() { Data = true };
        //        }

        //        //customer.IsDeleted = false;
        //        //_db.Add(customer);
        //        //_db.SaveChanges();

        //        //return new ResponseModel<bool>() { Data = true };
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return new ResponseModel<bool>() { Error = ex.Message, Data = false };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseModel<bool>() { Error = "An error occurred while creating the customer.", Data = false };
        //    }


        //}

        //public async Task<IResponse<int>> DeleteOrders(long id)
        //{
        //    var customer = _db.Orders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        //    if (customer == null)
        //    {
        //        return new ResponseModel<int> { Error = "Orders not found", Data = 0 };
        //    }
        //    customer.IsDeleted = true;
        //    _db.Update(customer);
        //    _db.SaveChanges();

        //    return new ResponseModel<int> { Error = null, Data = customer.Id };

        //}


    }
}

