using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class OfficeUpdateCommand : IRequest<Office>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}