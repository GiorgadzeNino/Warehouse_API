﻿
using AutoMapper;
using BTUProject.DataAccess;
using BTUProject.Dto.Customer;
using BTUProject.Dto.Gender;
using BTUProject.Interfaces;

namespace BTUProject.Service
{
    public class GenderAppService : IGenderAppSevice
    {
        private readonly WarehouseDbContext _db;
        private readonly IMapper _mapper;
        public GenderAppService(
            WarehouseDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //public async Task<IResponse<GenderDto>> Get()
        //{
        //    return new ResponseModel<GenderDto>()
        //    {
        //        Data =
        //        _mapper.Map<GenderDto>(_db.Gender.FirstOrDefault(x => x.Id >= 0))
        //    };
        //}

        public async Task<IResponse<GenderDto>> GetPersonDetails(long id)
        {
            return new ResponseModel<GenderDto>()
            {
                Data =
                _mapper.Map<GenderDto>(_db.Gender.FirstOrDefault(x => x.Id == id))
            };
        }

        public async Task<IResponse<bool>> CreateCustomer(CustomerDto input)
        {
            CustomerDto c = new CustomerDto();
            var customer = _mapper.Map<Customer>(input);
            customer = _db.Customer.FirstOrDefault();

            //var createPersonFirstname = _db.Customer.FirstOrDefault(x => x.Id == vacancy.CreatePersonId).Firstname;
            //var createPersonLastname = _db.Persons.FirstOrDefault(x => x.Id == vacancy.CreatePersonId).Lastname;
            //customer.CreatePersonName = createPersonFirstname + ' ' + createPersonLastname;

            //_db.Add(vacancy);
            //if (userId != 0)
            //{
            //    vp.IsApproved = false;
            //    vp.PersonId = userId;
            //    vacancy.AddPerson(_mapper.Map<VacancyPerson>(vp));
            //}
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };

        }


        //public async Task<IResponse<List<GenderWithIdDto>>> GetPersonList(int? categoryId, string? location, string? skills)
        //{
        //    return new ResponseModel<List<GenderWithIdDto>>()
        //    {
        //        Data =
        //        _mapper.Map<List<GenderWithIdDto>>(_db.Persons.Where(x => x.IsDeleted == false && (x.CategoryId == categoryId || categoryId == null) && x.Skills.Contains(skills ?? "") && x.Location.Contains(location ?? "") && x.IsActive == true).OrderBy(x => System.Convert.ToInt32(x.Id)).ToList())
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

        //public async Task<IResponse<bool>> Register(GenderDto input)
        //{
        //    var person = _mapper.Map<Person>(input);
        //    person.Password = _jwtPasswordService.HashPassword(person.Password);
        //    _db.Add(person);
        //    _db.SaveChanges();
        //    return new ResponseModel<bool>() { Data = true };
        //}

        //public async Task<IResponse<bool>> Update(GenderDto input)
        //{

        //    var person = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId());
        //    if (person != null)
        //    {
        //        _mapper.Map(input, person);
        //    }

        //    _db.Update(person);
        //    _db.SaveChanges();
        //    return new ResponseModel<bool>() { Data = true };
        //}
    }
}
