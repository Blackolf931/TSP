using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class OfficeUpdateCommandHandler : IRequestHandler<OfficeUpdateCommand, Office>
    {
        private readonly IRepositoryContext _context;

        public OfficeUpdateCommandHandler(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<Office> Handle(OfficeUpdateCommand request, CancellationToken cancellationToken)
        {
            var office = _context.Offices.Where(a => a.OfficeId == request.Id).FirstOrDefault();
            if (office is null)
            {
                return default;
            }
            office.OfficeId = request.Id;
            office.Name = request.Name;
            office.Address = request.Address;
            office.Country = request.Country;
            await _context.SaveChangesAsync();
            return office;
        }
    }
}