using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class DeleteOfficeByIdHandlerCommand : IRequestHandler<DeleteOfficeByIdCommand, Office>
    {
        private readonly IRepositoryContext _context;

        public DeleteOfficeByIdHandlerCommand(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<Office> Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
        {
            var office = await _context.Offices.Where(x => x.OfficeId == request.Id).FirstOrDefaultAsync();
            if (office is null)
            {
                return default;
            }
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
            return office;
        }
    }
}