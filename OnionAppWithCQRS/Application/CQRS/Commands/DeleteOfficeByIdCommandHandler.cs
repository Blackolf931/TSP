using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class DeleteOfficeByIdCommandHandler : IRequestHandler<DeleteOfficeByIdCommand, bool>
    {
        private readonly IRepositoryBase<Office> _repositoryBase;
        public DeleteOfficeByIdCommandHandler(IRepositoryBase<Office> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
        {
            var office = _repositoryBase.FindByIdAsync(request.Id);
            await _repositoryBase.DeleteByIdAsync(await office);
            return true;
        }
    }
}