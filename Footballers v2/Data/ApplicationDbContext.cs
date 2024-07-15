using Footballers_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace Footballers_v2.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Footballer> Footballers { get; set; }
    }
}
