using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class OfficeUpdateCommandHandler : IRequestHandler<OfficeUpdateCommand, Office>
    {
        private readonly IRepositoryContext _context;
        private readonly IMapper _mapper;

        public OfficeUpdateCommandHandler(IRepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Office> Handle(OfficeUpdateCommand request, CancellationToken cancellationToken)
        {
            var office = _context.Offices.Where(a => a.OfficeId == request.OfficeId).AsNoTracking().FirstOrDefault();
            if (office is null)
            {
                return default;
            }
            var mappedObject = _mapper.Map<Office>(request);
            _context.Offices.Update(mappedObject);
            await _context.SaveChangesAsync();
            return mappedObject;
        }
    }
}