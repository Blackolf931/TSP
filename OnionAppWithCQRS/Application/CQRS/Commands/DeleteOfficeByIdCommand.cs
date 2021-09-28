using Domain;
using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteOfficeByIdCommand : IRequest<Office>
    {
        public int Id { get; set; }
    }
}