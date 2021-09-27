using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetAllOfficeQueryHandler : IRequestHandler<GetAllOfficeQuery, IEnumerable<Office>>
    {
        private readonly IAppDbContext _context;

        public GetAllOfficeQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Office>> Handle(GetAllOfficeQuery request, CancellationToken cancellationToken)
        {
            var offices = await _context.Offices.ToListAsync();
            if (offices is null)
            {
                return null;
            }
            return offices.AsReadOnly();
        }
    }
}
