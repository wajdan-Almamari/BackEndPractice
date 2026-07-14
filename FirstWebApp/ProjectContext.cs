using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp
{
    public class ProjectContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-U403BM4;Database=ProjectDataStore;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}