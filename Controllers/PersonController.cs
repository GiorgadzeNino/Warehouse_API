using BTUProject.DataAccess;
using BTUProject.Dto;
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
    public class PersonController : ControllerBase
    {
        private readonly IGenderAppSevice _Service;
        public PersonController(IGenderAppSevice service)
        {
            _Service = service;
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IResponse<bool>> Register([FromBody] GenderDto input)
        //{
        //    var result = _Service.Register(input);
        //    return await result;
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IResponse<string>> Login([FromBody] LoginDto input)
        //{
        //    var result = _Service.Login(input);
        //    return await result;

        //}
        //[HttpPut]
        //public async Task<IResponse<bool>> Update([FromBody] PersonDto input)
        //{
        //    var result = _Service.Update(input);
        //    return await result;

        //}
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IResponse<GenderDto>> Get()
        {
            var result = _Service.Get();
            return await result;
        }
        //[HttpGet]
        //public async Task<IResponse<PersonDto>> GetPersonsDetiles(long id)
        //{
        //    var result = _Service.GetPersonDetails(id);
        //    return await result;
        //}
        //[HttpGet]
        //public async Task<IResponse<List<PersonWithIdDto>>> GetList(int? categoryId,string? location, string? skills)
        //{
        //    var result = _Service.GetPersonList(categoryId, location, skills);
        //    return await result;
        //}
    }
}
