using Bouwmarkt_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Bouwmarkt_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Vestiging> Vestigingen { get; set; }
    }
}
