using Domain;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.CQRS.Queries
{
    public class GetOfficeByIdQuery : IRequest<Office>
    {
        [Column("OfficeId")]
        public int Id { get; set; }
    }
}