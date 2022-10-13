namespace ApplicationIdentity2.Contracts
{
    public interface IAuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
