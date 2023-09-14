using APICatalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.PortableExecutable;

namespace APICatalog.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {
                
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
