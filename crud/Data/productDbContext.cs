using crud.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class productDbContext : DbContext
    {
        
        public productDbContext(DbContextOptions<productDbContext> option):base(option)
        {
        }


     public DbSet<Product> products {  get; set; }
    }
}
