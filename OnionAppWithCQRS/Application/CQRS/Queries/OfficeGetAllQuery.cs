using Domain;
using MediatR;
using System.Collections.Generic;

namespace Application.CQRS.Queries
{
    public class OfficeGetAllQuery : IRequest<IEnumerable<Office>>
    {
    }
}