namespace BTUProject.DataAccess
{
    public class RelationshipTypes : Base
    {

        public RelationshipTypes() { }

        public RelationshipTypes(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
