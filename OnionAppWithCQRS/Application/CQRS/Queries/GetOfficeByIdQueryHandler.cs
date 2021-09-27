using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetOfficeByIdQueryHandler : IRequestHandler<GetOfficeByIdQuery, Office>
    {
        private readonly IAppDbContext _context;

        public GetOfficeByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Office> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            var office = await _context.Offices.Where(x => x.OfficeId == request.OfficeId).FirstOrDefaultAsync();
            if (office is null)
            {
                return default;
            }
            return office;
        }
    }
}
