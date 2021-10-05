using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<SuplierProduct> SuplierProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9G1AL38;Initial Catalog=Shop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__ProductI__31EC6D26");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__32E0915F");
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__Supliers__4BE666B4276901DD");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SurName).HasMaxLength(50);
            });

            modelBuilder.Entity<SuplierProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Suplier_Products");

                entity.HasOne(d => d.Products)
                    .WithMany()
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suplier_P__Produ__2C3393D0");

                entity.HasOne(d => d.Supplier)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suplier_P__Suppl__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
