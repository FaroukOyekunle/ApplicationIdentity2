namespace ApplicationIdentity2.Contracts
{
    public interface ISoftDelete
    {   int DeletedBy { get; set; }
        DateTime DeletedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
