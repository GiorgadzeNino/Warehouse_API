
using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto.Customer;
using BTUProject.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            var customer = await _db.Customer.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                // Handle the case where the customer with the given id doesn't exist
                return new ResponseModel<CustomerDto> { Error = "Customer not found", Data = null };
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return new ResponseModel<CustomerDto> { Data = customerDto };
        }

        //public async Task<IResponse<CustomersDto>> Get()
        //{
        //    return new ResponseModel<CustomerDto>()
        //    {
        //        Data =
        //        _mapper.Map<CustomerDto>(_db.Customer.FirstOrDefault(x => x.Id >= 0))
        //    };
        //}
        //public async Task<IResponse<List<CustomerWithIdDto>>> GetPersonList(int? categoryId, string? location, string? skills)
        //{
        //    return new ResponseModel<List<CustomerWithIdDto>>()
        //    {
        //        Data =
        //        _mapper.Map<List<CustomerWithIdDto>>(_db.Persons.Where(x => x.IsDeleted == false && (x.CategoryId == categoryId || categoryId == null) && x.Skills.Contains(skills ?? "") && x.Location.Contains(location ?? "") && x.IsActive == true).OrderBy(x => System.Convert.ToInt32(x.Id)).ToList())
        //    };
        //}


        //public async Task<IResponse<string>> Login(LoginDto input)
        //{
        //    var person = _db.Persons.FirstOrDefault(x => x.Username == input.UserName);
        //    if (person == null)
        //    {
        //        return new ResponseModel<string>() { Error = "Invalid userName or password", Data = null };
        //    }
        //    string token = "";
        //    if (_jwtPasswordService.ValidatePassword(input.Password, person.Password))
        //    {
        //        token = _jwtPasswordService.GenerateJwtToken(person.Username, person.Id);
        //    }
        //    if (token == "")
        //    {
        //        return new ResponseModel<string>() { Error = "Invalid userName or password", Data = null };
        //    }
        //    return new ResponseModel<string>() { Data = token };
        //}

        //public async Task<IResponse<bool>> Register(CustomerDto input)
        //{
        //    var person = _mapper.Map<Person>(input);
        //    person.Password = _jwtPasswordService.HashPassword(person.Password);
        //    _db.Add(person);
        //    _db.SaveChanges();
        //    return new ResponseModel<bool>() { Data = true };
        //}

        //public async Task<IResponse<bool>> Update(CustomerDto input)
        //{

        //    var person = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId());
        //    if (person != null)
        //    {
        //        _mapper.Map(input, person);
        //    }dfs

        //    _db.Update(person);
        //    _db.SaveChanges();
        //    return new ResponseModel<bool>() { Data = true };
        //}
    }
}
