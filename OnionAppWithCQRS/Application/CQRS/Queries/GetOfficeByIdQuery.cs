using Domain;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetOfficeByIdQuery : IRequest<Office>
    {
        public int OfficeId { get; set; }
    }
}