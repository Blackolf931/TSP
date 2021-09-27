using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteOfficeByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
