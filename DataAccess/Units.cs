namespace BTUProject.DataAccess
{
    public class Units : Base
    {

        public Units() { }
        public Units(int id, string name, string shortName)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
