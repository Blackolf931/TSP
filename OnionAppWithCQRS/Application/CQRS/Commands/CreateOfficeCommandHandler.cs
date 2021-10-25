using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Office>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Office> _repositoryBase;
        public CreateOfficeCommandHandler(IMapper mapper, IRepositoryBase<Office> repositoryBase)
        {
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }

        public async Task<Office> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            await _repositoryBase.AddAsync(_mapper.Map<Office>(request));
            return _mapper.Map<Office>(request);
        }
    }
}