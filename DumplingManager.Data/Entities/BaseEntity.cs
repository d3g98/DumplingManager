namespace DumplingManager.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime TimeCreated { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTime TimeModified { get; set; }
        public Guid UserModifiedId { get; set; }
        public string Note { get; set; }
    }
}