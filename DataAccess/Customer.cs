using System.ComponentModel.DataAnnotations;

namespace BTUProject.DataAccess
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int id, string firstName, string lastName, int genderId, string personalNumber, DateTime birthDate, int cityId, int countryId, string email, Gender gender, Cities cities, Countries countries)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            GenderId = genderId;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            CityId = cityId;
            CountryId = countryId;
            Email = email;
            Gender = gender;
            Cities = cities;
            Countries = countries;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual ICollection<CustomersRelationships> StartCustomersRelationships { get; set; }
        public virtual ICollection<CustomersRelationships> EndCustomersRelationships { get; set; }

    }
}
