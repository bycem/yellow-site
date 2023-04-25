using Domain.Abstractions;

namespace Domain.Models
{
    public class Customer : BaseEntity,IAggregateRoot
    {
        public Customer(Guid id, string username, string email, DateTime? createDate = null) : base(id, createDate)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; protected set; }
        
        public string Email { get; protected set; }
    }
}
