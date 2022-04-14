using Microsoft.EntityFrameworkCore;

namespace BouwmarktAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Vestiging> Vestigingen { get; set; }
    }
}
