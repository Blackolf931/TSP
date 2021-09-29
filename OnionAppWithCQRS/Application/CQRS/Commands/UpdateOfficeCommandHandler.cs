using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand, Office>
    {
        private readonly IRepositoryBase<Office> _repositoryBase;
        private readonly IMapper _mapper;

        public UpdateOfficeCommandHandler(IRepositoryBase<Office> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task<Office> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            var mappedObject = _mapper.Map<Office>(request);
            return await _repositoryBase.UpdateAsync(mappedObject);
        }
    }
}