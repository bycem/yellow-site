using Domain.Abstractions;

namespace Domain.Models
{
    public class Customer : BaseEntity,IAggregateRoot
    {
        public Customer(Guid id, string username, string email, string password, DateTime? createDate = null) : base(id, createDate)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; protected set; }
        
        public string Email { get; protected set; }

        public string Password { get; protected set; }
    }
}
