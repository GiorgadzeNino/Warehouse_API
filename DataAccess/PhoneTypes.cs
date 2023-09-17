namespace BTUProject.DataAccess
{
    public class PhoneTypes
    {
        public PhoneTypes() { }

        public PhoneTypes(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
