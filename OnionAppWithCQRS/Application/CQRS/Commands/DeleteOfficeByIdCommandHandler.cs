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
            var office = await _repositoryBase.FindByIdAsync(request.Id);
            await _repositoryBase.DeleteByIdAsync(office);
            return true;
        }
    }
}