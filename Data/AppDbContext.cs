using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestWeb.Models;


namespace TestWeb.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // hna ana bolh htly ale data base ale asmha TestItemcs
        public DbSet<TestItemcs>Items {get;set;}
        public DbSet<Category> Categories {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name = "Select Category" },
                    new Category() { Id = 2, Name = "Phone" },
                    new Category() { Id = 3, Name = "T.v" },
                    new Category() { Id = 4, Name = "Laptop" },
                    new Category() { Id = 5, Name = "T.Shert" }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "admin", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "user", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Sales", NormalizedName = "sales", ConcurrencyStamp = Guid.NewGuid().ToString() }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
