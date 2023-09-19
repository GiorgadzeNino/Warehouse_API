
using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto.Customer;
using BTUProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTUProject.Service
{
    public class CustomerAppService : ICustomerAppSevice
    {
        private readonly WarehouseDbContext _db;
        private readonly IMapper _mapper;

        public CustomerAppService(
            WarehouseDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IResponse<CustomerDto>> GetCustomerDetails(long id)
        {
            var customer = _db.Customer.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (customer == null)
            {
                // Handle the case where the customer with the given id doesn't exist
                return new ResponseModel<CustomerDto> { Error = "Customer not found", Data = null };
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return new ResponseModel<CustomerDto> { Data = customerDto };
        }

        public async Task<IResponse<bool>> CreateCustomer(CustomerDto input)
        {
            try
            {
                var customer = _mapper.Map<Customer>(input);

                if (DateTime.Today.AddYears(-18) < customer.BirthDate)
                {
                    throw new ArgumentException("Customer must be at least 18 years old.");
                }
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // Use Regex.IsMatch to check if the email matches the pattern
                var emailIsValid = Regex.IsMatch(input.Email, pattern);
                if (!emailIsValid)
                {
                    throw new ArgumentException("Invalid email address format.", nameof(input.Email));
                }
                customer.IsDeleted = false;
                _db.Add(customer);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the customer.", Data = false };
            }
        }

        public async Task<IResponse<bool>> UpdateCustomer(CustomerWithIdDto input)
        {
            try
            {
                var customer = _db.Customer.FirstOrDefault(x => x.Id == input.Id && !x.IsDeleted);
                if (customer != null)
                {
                    _mapper.Map(input, customer);
                }


                if (DateTime.Today.AddYears(-18) < customer.BirthDate)
                {
                    throw new ArgumentException("Customer must be at least 18 years old.");
                }


                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // Use Regex.IsMatch to check if the email matches the pattern
                var emailIsValid = Regex.IsMatch(input.Email, pattern);
                if (!emailIsValid)
                {
                    throw new ArgumentException("Invalid email address format.", nameof(input.Email));
                }
                else
                {
                    _db.Update(customer);
                    _db.SaveChanges();
                    return new ResponseModel<bool>() { Data = true };
                }

                //customer.IsDeleted = false;
                //_db.Add(customer);
                //_db.SaveChanges();

                //return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the customer.", Data = false };
            }


        }

        public async Task<IResponse<int>> DeleteCustomer(long id)
        {
            var customer = _db.Customer.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (customer == null)
            {
                return new ResponseModel<int> { Error = "Customer not found", Data = 0 };
            }
            customer.IsDeleted = true;
            _db.Update(customer);
            _db.SaveChanges();

            return new ResponseModel<int> { Error = null, Data = customer.Id };

        }

        public async Task<IResponse<List<CustomerWithIdDto>>> GetCustomersList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize)
        {
            var query = _db.Customer
                .AsNoTracking()
             .Where(x =>
                 !x.IsDeleted &&
                 (genderId != null && x.GenderId == genderId) &&
                 (personalNumber != null && x.PersonalNumber == personalNumber) &&
                 (email != null && x.Email == email) &&
                 (cityId != null && x.Cities.Id == cityId))
             .OrderBy(x => x.Id);

            int recordsToSkip = (pageNumber - 1) * pageSize;

            // Apply paging to the query
            var pagedQuery = query.Skip(recordsToSkip).Take(pageSize);

            // Execute the query and retrieve the results
            var results = pagedQuery.ToList();

            // Map the results to DTOs
            var dtos = _mapper.Map<List<CustomerWithIdDto>>(results);

            // Return the paged results
            return new ResponseModel<List<CustomerWithIdDto>>()
            {
                Data = dtos
            };
        }

        public async Task<IResponse<bool>> MakeCustomerRelationShip(MakeRelationshipDto model)
        {
            try
            {
                var customersRelationShips = new CustomersRelationships
                {
                    StartCustomerId = model.StartCustomerId,
                    EndCustomerId = model.EndCustomerId,
                    RelationshipTypeId = model.RelationShipTypeId,
                    Comment = model.Comment,
                    IsDeleted = false,
                    IsActive = true
                };
                _db.Add(customersRelationShips);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while creating the relationships.", Data = false };
            }
        }

        public async Task<IResponse<bool>> UpdateCustomerRelationShip(MakeRelationshipWithIdDto model)
        {
            try
            {

                var customersRelationShips = _db.CustomersRelationships.FirstOrDefault(x => x.Id == model.Id && !x.IsDeleted);
                if (customersRelationShips != null)
                {
                    _mapper.Map(model, customersRelationShips);
                }

                _db.Update(customersRelationShips);
                _db.SaveChanges();

                return new ResponseModel<bool>() { Data = true };
            }
            catch (ArgumentException ex)
            {
                return new ResponseModel<bool>() { Error = ex.Message, Data = false };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>() { Error = "An error occurred while updating the relationships.", Data = false };
            }
        }

        public async Task<IResponse<int>> DeleteCustomerRelationShip(int id)
        {
            var customersRelationships = _db.CustomersRelationships.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (customersRelationships == null)
            {
                return new ResponseModel<int> { Error = "Customer relationship not found", Data = 0 };
            }
            customersRelationships.IsDeleted = true;
            _db.Update(customersRelationships);
            _db.SaveChanges();

            return new ResponseModel<int> { Error = null, Data = customersRelationships.Id };

        }

    }
}

