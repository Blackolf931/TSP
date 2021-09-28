﻿using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class OfficeGetByIdQueryHandler : IRequestHandler<OfficeGetByIdQuery, Office>
    {
        private readonly IRepositoryContext _context;

        public OfficeGetByIdQueryHandler(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<Office> Handle(OfficeGetByIdQuery request, CancellationToken cancellationToken)
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