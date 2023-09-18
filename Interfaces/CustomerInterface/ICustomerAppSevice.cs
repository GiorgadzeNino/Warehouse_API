using BTUProject.DataAccess;
using BTUProject.Dto;
using BTUProject.Dto.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTUProject.Interfaces
{
    public interface ICustomerAppSevice
    {
        //Task<BTUProject.DataAccess.IResponse<bool>> Register(PersonDto input);
        //Task<BTUProject.DataAccess.IResponse<string>> Login(LoginDto input);
        Task<IResponse<List<CustomerWithIdDto>>> GetCustomersList(int? genderId, string? personalNumber, string? email, int? cityId, int pageNumber, int pageSize);
        Task<IResponse<CustomerDto>> GetCustomerDetails(long id);
        Task<IResponse<bool>> CreateCustomer(CustomerDto input);
        Task<IResponse<bool>> UpdateCustomer(CustomerWithIdDto input);
        Task<IResponse<int>> DeleteCustomer(long id);

        //Task<BTUProject.DataAccess.IResponse<bool>> Update(PersonDto input);

    }
}
