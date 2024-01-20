namespace StockApp.Api.Core.Helper
{
    public class TrackedAggregateRoot<TPrimaryKey>
    {
        public virtual Guid? Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual Guid? DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierId { get; set; }
        public virtual DateTime? CreationTime { get; protected set; }
        public virtual Guid? CreatorId { get; protected set; }
    }
}
