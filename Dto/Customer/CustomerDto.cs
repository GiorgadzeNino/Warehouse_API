using System;

namespace BTUProject.Dto.Customer
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
     
    }
}
