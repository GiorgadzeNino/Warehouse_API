namespace BTUProject.DataAccess
{
    public class CustomersPhoneNumbers : Base
    {
        public CustomersPhoneNumbers() { }
        public CustomersPhoneNumbers(int id, int phoneTypeId, int customerId, string phoneNumber, bool isMain)
        {
            Id = id;
            PhoneTypeId = phoneTypeId;
            CustomerId = customerId;
            PhoneNumber = phoneNumber;
            IsMain = isMain;
        }

        public int Id { get; set; }
        public int PhoneTypeId { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMain { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PhoneTypes PhoneTypes { get; set; }
    }
}
