using Microsoft.EntityFrameworkCore;
using APIDemo.Models;

namespace APIDemo.Models
{
    public class DemoContext: DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public DbSet<Person>People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public DbSet<APIDemo.Models.DemoModel>? DemoModel { get; set; }
        
    }
}
