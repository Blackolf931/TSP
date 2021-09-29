using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class OfficeDeleteByIdHandlerCommand : IRequestHandler<OfficeDeleteByIdCommand, bool>
    {
        private readonly IRepositoryContext _context;

        public OfficeDeleteByIdHandlerCommand(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(OfficeDeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var office = await _context.Offices.Where(x => x.OfficeId == request.Id).FirstOrDefaultAsync();
            if (office is null)
            {
                return false;
            }
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}