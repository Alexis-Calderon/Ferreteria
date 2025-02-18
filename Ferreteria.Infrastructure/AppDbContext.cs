using System;

using Ferreteria.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ferreteria.Infrastructure;

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
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product", "ferreteria");
            entity.HasKey(e => e.IdProduct);
            entity.Property(e => e.IdProduct).HasColumnName("id_product").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.Category).HasColumnName("category").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Brand).HasColumnName("brand").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnName("price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Stock).HasColumnName("stock").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MeasurementUnit).HasColumnName("measurement_unit").HasColumnType("TEXT").HasMaxLength(10);
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier").HasColumnType("INTEGER");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
        });
    }
}