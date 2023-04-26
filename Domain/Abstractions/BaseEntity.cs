namespace Domain.Abstractions
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid? id, DateTime? createDate = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty");
            if (createDate == DateTime.MinValue) throw new ArgumentException("Create date cannot be datetime min value");

            Id = id ?? Guid.NewGuid();
            CreateDate = createDate ?? DateTime.Now;
        }

        protected BaseEntity(Guid id, DateTime createDate)
        {
            Id = id;
            CreateDate = createDate;
        }

        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
    }
}
