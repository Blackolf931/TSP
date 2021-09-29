using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateOfficeCommand : IRequest<OfficeAddModel>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}