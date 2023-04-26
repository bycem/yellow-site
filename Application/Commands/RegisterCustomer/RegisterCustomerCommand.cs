using MediatR;

namespace Application.Commands.RegisterCustomer;

public class RegisterCustomerCommand : IRequest<RegisterCustomerCommandRepresentation>
{
    public string UserId { get; set; }

    public string Username { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
}

