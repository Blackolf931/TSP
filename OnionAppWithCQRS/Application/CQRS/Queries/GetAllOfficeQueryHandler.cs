using Application.Interfaces;
using Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetAllOfficeQueryHandler : IRequestHandler<GetAllOfficeQuery, IEnumerable<Office>>
    {
        private readonly IRepositoryBase<Office> _repositoryBase;

        public GetAllOfficeQueryHandler(IRepositoryBase<Office> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<IEnumerable<Office>> Handle(GetAllOfficeQuery request, CancellationToken cancellationToken)
        {
            var offices = await _repositoryBase.FindAllAsync();
            return offices;
        }
    }
}