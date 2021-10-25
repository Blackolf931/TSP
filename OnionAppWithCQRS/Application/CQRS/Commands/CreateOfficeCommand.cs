using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateOfficeCommand : IRequest<Office>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}