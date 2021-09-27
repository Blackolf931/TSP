using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class CreateOfficeHandlerCommand : IRequestHandler<CreateOfficeCommand, int>
    {
        private readonly IAppDbContext _context;
        public CreateOfficeHandlerCommand(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            Office office = new();
            office.Name = request.Name;
            office.Country = request.Country;
            office.Address = request.Address;
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
            return office.OfficeId;
        }
    }
}