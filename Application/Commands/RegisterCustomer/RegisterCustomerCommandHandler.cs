using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, RegisterCustomerCommandRepresentation>
    {
        private readonly ICustomerRepository _customerRepository;


        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
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
