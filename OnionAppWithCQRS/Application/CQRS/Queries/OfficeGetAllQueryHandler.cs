using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class OfficeGetAllQueryHandler : IRequestHandler<OfficeGetAllQuery, IEnumerable<Office>>
    {
        private readonly IRepositoryContext _context;

        public OfficeGetAllQueryHandler(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Office>> Handle(OfficeGetAllQuery request, CancellationToken cancellationToken)
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