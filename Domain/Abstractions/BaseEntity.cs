namespace Domain.Abstractions
{
    public abstract class BaseEntity
    {
        protected internal BaseEntity()
        {
        }

        protected BaseEntity(Guid? id, DateTime? updateDate, DateTime? createDate = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty");
            if (createDate == DateTime.MinValue) throw new ArgumentException("Create date cannot be datetime min value");

            UpdateDate = updateDate;

            Id = id ?? Guid.NewGuid();
            CreateDate = createDate ?? DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
    }
}
