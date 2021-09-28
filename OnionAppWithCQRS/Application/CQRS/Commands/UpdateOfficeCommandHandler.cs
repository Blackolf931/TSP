using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand, int>
    {
        private readonly IAppDbContext _context;

        public UpdateOfficeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = _context.Offices.Where(a => a.OfficeId == request.OfficeId).FirstOrDefault();
            if (office is null)
            {
                return default;
            }
            office.Name = request.Name;
            office.Address = request.Address;
            office.Country = request.Country;
            await _context.SaveChangesAsync();
            return office.OfficeId;
        }
    }
}