using Microsoft.EntityFrameworkCore;

namespace Bouwmarkt_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Vestiging> Vestigingen { get; set; }
    }
}
