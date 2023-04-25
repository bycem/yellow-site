namespace Domain.Abstractions
{
    public class BaseEntity
    {
        public BaseEntity(Guid? id, DateTime? createDate = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty");
            if (createDate == DateTime.MinValue) throw new ArgumentException("Create date cannot be datetime min value");

            Id = id ?? Guid.NewGuid();
            CreateDate = createDate ?? DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
    }
}
