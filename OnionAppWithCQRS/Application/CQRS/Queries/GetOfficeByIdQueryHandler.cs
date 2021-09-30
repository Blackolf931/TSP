using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetOfficeByIdQueryHandler : IRequestHandler<GetOfficeByIdQuery, Office>
    {
        private readonly IRepositoryBase<Office> _repositoryBase;

        public GetOfficeByIdQueryHandler(IRepositoryBase<Office> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Office> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            var office = await _repositoryBase.FindByIdAsync(request.OfficeId);
            return office;
        }
    }
}