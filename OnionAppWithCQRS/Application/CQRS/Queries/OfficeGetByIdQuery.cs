using Domain;
using MediatR;

namespace Application.CQRS.Queries
{
    public class OfficeGetByIdQuery : IRequest<Office>
    {
        public int OfficeId { get; set; }
    }
}