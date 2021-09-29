using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositoryContext
    {
        DbSet<Office> Offices { get; set; }
        Task<int> SaveChangesAsync();
    }
}