using EF_day2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_day2.Models
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.CategoryId);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500)
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);
            // modelBuilder.Entity<Product>()
            //                 .HasOne<Category>(p => p.Category)
            //                 .WithMany(p => p.Product)
            //                 .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                            .Property(p => p.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(100)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.Manufacture)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);
                            
            modelBuilder.Entity<Product>()
                            .Property(p => p.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Computer"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Computer",
                    Manufacture = "test",
                    CategoryId = 1
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}