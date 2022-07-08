using Microsoft.EntityFrameworkCore;
using System.IO;


namespace NorthwindLibrary 
{
    public class NorthwindDbContext : DbContext 
    {
        public NorthwindDbContext (DbContextOptions<NorthwindDbContext> options) : base (options) 
        { 
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
