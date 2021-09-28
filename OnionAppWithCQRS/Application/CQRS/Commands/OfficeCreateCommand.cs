using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class OfficeCreateCommand : IRequest<OfficeAddEntity>
    {
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Country { get; set; }
    }
}