namespace BTUProject.Dto.Customer
{
    public class MakeRelationshipDto
    {
        public int StartCustomerId { get; set; }
        public int EndCustomerId { get; set; }
        public int RelationShipTypeId { get; set; }
        public string Comment { get; set; }
    }
}
