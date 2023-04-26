using Domain.Abstractions;

namespace Domain.Models
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Customer(Guid? id, string username, string email, string fullName, string userId, DateTime? createDate = null) : base(id, createDate)
        {
            Username = username;
            Email = email;
            FullName = fullName;
            UserId = userId;
        }

        public Customer(Guid id, string username, string email, string fullName, string userId, DateTime createDate) : base(id, createDate)
        {
            Username = username;
            Email = email;
            FullName = fullName;
            UserId = userId;
        }

        public string Username { get; protected set; }

        public string Email { get; protected set; }

        public string FullName { get; protected set; }

        public string UserId { get; protected set; }
    }
}
