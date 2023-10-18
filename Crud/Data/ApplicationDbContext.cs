using Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
      
        public DbSet<Info> infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Info>().HasData(
                new Info { id = 1, name = "uttam", address = "Charpane", email = "Uttam@gmail.com", phoneNo = "9812345678", parentName="kumari"  },
                new Info { id = 2, name = "Mettam", address = "Charpane", email = "Mttam@gmail.com", phoneNo = "9812345678", parentName="sunita" }
            );
        }

    }
}
