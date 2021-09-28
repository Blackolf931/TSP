using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateOfficeCommand : IRequest<int>
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}