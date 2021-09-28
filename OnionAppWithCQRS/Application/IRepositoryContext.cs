using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public interface IRepositoryContext
    {
        DbSet<Office> Offices { get; set; }
        Task<int> SaveChangesAsync();
    }
}