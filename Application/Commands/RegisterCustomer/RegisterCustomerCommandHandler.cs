using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, RegisterCustomerCommandRepresentation>
    {
        private readonly IRepository<Customer> _customerRepository;


        public RegisterCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RegisterCustomerCommandRepresentation> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {

            var result = await _customerRepository.CreateAsync(new Customer(null,
                request.Username,
                request.Email,
                request.FullName,
                request.UserId));

            return new RegisterCustomerCommandRepresentation()
            {
                Id = result
            };
        }
    }
}
