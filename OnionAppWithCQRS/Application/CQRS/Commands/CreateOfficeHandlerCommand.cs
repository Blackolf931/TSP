using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class CreateOfficeHandlerCommand : IRequestHandler<CreateOfficeCommand, OfficeAddEntity>
    {
        private readonly IRepositoryContext _context;
        private readonly IMapper _mapper;
        public CreateOfficeHandlerCommand(IRepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OfficeAddEntity> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            _context.Offices.Add(_mapper.Map<Office>(request));
            await _context.SaveChangesAsync();
            return _mapper.Map<OfficeAddEntity>(request);
        }
    }
}