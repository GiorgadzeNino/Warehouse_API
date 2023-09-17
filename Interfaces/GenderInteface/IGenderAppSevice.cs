using BTUProject.DataAccess;
using BTUProject.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Interfaces
{
    public interface IGenderAppSevice
    {
        //Task<BTUProject.DataAccess.IResponse<bool>> Register(PersonDto input);
        //Task<BTUProject.DataAccess.IResponse<string>> Login(LoginDto input);
        Task<IResponse<GenderDto>> Get();
        //Task<IResponse<PersonDto>> GetPersonDetails(long id);
        //Task<IResponse<List<PersonWithIdDto>>> GetPersonList(int? categoryId, string? location, string? skills);
        //Task<BTUProject.DataAccess.IResponse<bool>> Update(PersonDto input);

    }
}
