using Microsoft.EntityFrameworkCore;

namespace StoreAPI.Entities
{
    public class AppDbContext :DbContext
    {

        // 

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }


        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory() { Name = "Mobiles", PCId = 1 },
                new ProductCategory() { Name = "Printers", PCId = 2 },
                new ProductCategory() { Name = "Computers", PCId = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
              new Product() { Id=1,  Name = "Samsung S24 Ultra", CatId = 1 },
              new Product() { Id=2, Name = "HP Laserjet 3025", CatId = 2 },
              new Product() { Id=3, Name = "HP ProBook 15588", CatId = 3 }
              );
        }


    }
}
