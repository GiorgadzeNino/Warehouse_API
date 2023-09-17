namespace BTUProject.DataAccess
{
    public class CustomersRelationships : Base
    {
        public CustomersRelationships() { 
        
        }

        public CustomersRelationships(int id, int relationshipTypeId, int startCustomerId, int endCustomerId, string comment)
        {
            Id = id;
            RelationshipTypeId = relationshipTypeId;
            StartCustomerId = startCustomerId;
            EndCustomerId = endCustomerId;
            Comment = comment;
        }

        public int Id { get; set; }
        public int RelationshipTypeId { get; set; }
        public int StartCustomerId { get; set; }
        public int EndCustomerId { get; set; }
        public string Comment { get; set; }
        public virtual Customer StartCustomer { get; set; }
        public virtual Customer EndCustomer { get; set; }
        public virtual RelationshipTypes RelationshipTypes { get; set; }

    }
}
