using System;

using Ferreteria.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ferreteria.Infrastructure.Context;

public class AppDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnectionString"));
        }
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category", "ferreteria");
            entity.HasKey(e => e.IdCategory);
            entity.Property(e => e.IdCategory).HasColumnName("id_category").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client", "ferreteria");
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.IdClient).HasColumnName("id_client").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(50);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("NUMERIC");
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee", "ferreteria");
            entity.HasKey(e => e.IdEmployee);
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(30).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(30);
            entity.Property(e => e.JobPosition).HasColumnName("job_position").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.HiringDate).HasColumnName("hiring_date").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory", "ferreteria");
            entity.HasKey(e => e.IdInventory);
            entity.Property(e => e.IdInventory).HasColumnName("id_inventory").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdProduct).HasColumnName("id_product").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.CurrentStock).HasColumnName("current_stock").HasColumnName("INTEGER").IsRequired();
            entity.Property(e => e.UpdatedAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_inventory_product");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.ToTable("inventory_movement", "ferreteria");
            entity.HasKey(e => e.IdInventoryMovement);
            entity.Property(e => e.IdInventoryMovement).HasColumnName("id_inventory_movement").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdProduct).HasColumnName("id_product").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MovementType).HasColumnName("movement_type").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MovementDate).HasColumnName("movement_date").HasColumnType("TEXT").IsRequired();
            entity.Property(e => e.Reference).HasColumnName("reference").HasColumnType("TEXT").HasMaxLength(50);

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_inventory_movement_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product", "ferreteria");
            entity.HasKey(e => e.IdProduct);
            entity.Property(e => e.IdProduct).HasColumnName("id_product").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.IdCategory).HasColumnName("id_category").HasColumnType("INTEGER");
            entity.Property(e => e.Brand).HasColumnName("brand").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnName("price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Stock).HasColumnName("stock").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MeasurementUnit).HasColumnName("measurement_unit").HasColumnType("TEXT").HasMaxLength(10);
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier").HasColumnType("INTEGER");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_product_category");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_supplier");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("purchase", "ferreteria");
            entity.HasKey(e => e.IdPurchase);
            entity.Property(e => e.IdPurchase).HasColumnName("id_purchase").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier").HasColumnType("INTEGER");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee").HasColumnType("INTEGER");
            entity.Property(e => e.Total).HasColumnName("total").HasColumnType("NUMERIC");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date").HasColumnType("TEXT").IsRequired();

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_employee");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_supplier");
        });

        modelBuilder.Entity<PurchaseProduct>(entity =>
        {
            entity.ToTable("purchase_product", "ferreteria");
            entity.HasKey(e => e.IdPurchaseProduct);
            entity.Property(e => e.IdPurchaseProduct).HasColumnName("id_purchase_product").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdPurchase).HasColumnName("id_purchase").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.IdProduct).HasColumnName("id_product").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasColumnType("NUMERIC").IsRequired();

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PurchaseProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_product_product");

            entity.HasOne(d => d.IdPurchaseNavigation).WithMany(p => p.PurchaseProducts)
                .HasForeignKey(d => d.IdPurchase)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_product_purchase");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sale", "ferreteria");
            entity.HasKey(e => e.IdSale);
            entity.Property(e => e.IdSale).HasColumnName("id_sale").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdClient).HasColumnName("id_client").HasColumnType("INTEGER");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee").HasColumnType("INTEGER");
            entity.Property(e => e.Total).HasColumnName("total").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.SaleDate).HasColumnName("sale_date").HasColumnType("TEXT").IsRequired();

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_client");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_employee");
        });

        modelBuilder.Entity<SaleProduct>(entity =>
        {
            entity.ToTable("sale_product", "ferreteria");
            entity.HasKey(e => e.IdSaleProduct);
            entity.Property(e => e.IdSaleProduct).HasColumnName("id_sale_product").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.IdSale).HasColumnName("id_sale").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.IdProduct).HasColumnName("id_product").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasColumnType("NUMERIC").IsRequired();

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SaleProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_product_product");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleProducts)
                .HasForeignKey(d => d.IdSale)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_product_sale");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("supplier", "ferreteria");
            entity.HasKey(e => e.IdSupplier);
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
        });
    }
}