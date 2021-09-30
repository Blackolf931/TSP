using Domain;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.CQRS.Commands
{
    public class UpdateOfficeCommand : IRequest<Office>
    {
        [Column("OfficeId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}