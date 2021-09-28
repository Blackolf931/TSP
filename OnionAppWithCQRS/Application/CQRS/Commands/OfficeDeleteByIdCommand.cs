using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class OfficeDeleteByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}