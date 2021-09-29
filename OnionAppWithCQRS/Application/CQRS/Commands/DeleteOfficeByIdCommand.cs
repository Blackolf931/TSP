using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteOfficeByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}