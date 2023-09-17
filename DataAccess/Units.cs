namespace BTUProject.DataAccess
{
    public class Units : Base
    {

        public Units()
        {
            WareHouse = new HashSet<WareHouse>();
        }

        public Units(int id, string name, string shortName)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<WareHouse> WareHouse { get; set; }
    }
}
