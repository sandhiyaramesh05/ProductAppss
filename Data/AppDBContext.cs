using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace ProductApi.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
