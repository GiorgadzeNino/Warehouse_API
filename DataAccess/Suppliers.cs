namespace BTUProject.DataAccess
{
    public class Suppliers : Base
    {
        public Suppliers()
        {
            Cities = new HashSet<Cities>();
            Countries = new HashSet<Countries>();
        }

        public Suppliers(int id, string companyCode, string companyName, string companyFullName, int cityId, int countryId, string phone, string fax, string website, ICollection<Cities> cities, ICollection<Countries> countries)
        {
            Id = id;
            CompanyCode = companyCode;
            CompanyName = companyName;
            CompanyFullName = companyFullName;
            CityId = cityId;
            CountryId = countryId;
            Phone = phone;
            Fax = fax;
            Website = website;
            Cities = cities;
            Countries = countries;
        }

        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyFullName { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Cities> Cities { get; private set; }
        public virtual ICollection<Countries> Countries { get; private set; }
    }
}
