using ASP.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.repo
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Product> products { get; set; }
    }
}
