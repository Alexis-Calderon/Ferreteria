using Ferreteria.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
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
            entity.ToTable("category");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Name);
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255).IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Rut);
            entity.Property(e => e.Rut).HasColumnName("rut").HasColumnType("TEXT").HasMaxLength(15).IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("NUMERIC");
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.UserRut).HasColumnName("user_rut").HasColumnType("TEXT").HasMaxLength(15).IsRequired();
            entity.Property(e => e.JobPosition).HasColumnName("job_position").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.HiringDate).HasColumnName("hiring_date").HasColumnType("TEXT");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.UserRutNavigation).WithOne(p => p.EmployeeIdNavigation)
                .HasForeignKey<Employee>(d => d.UserRut)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_employee_user");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.ProductCode).HasColumnName("product_code").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.CurrentStock).HasColumnName("current_stock").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_inventory_product");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.ToTable("inventory_movement");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.ProductCode).HasColumnName("product_code").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.MovementType).HasColumnName("movement_type").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MovementDate).HasColumnName("movement_date").HasColumnType("TEXT").IsRequired();
            entity.Property(e => e.Reference).HasColumnName("reference").HasColumnType("TEXT").HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_inventory_movement_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasColumnName("code").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.CategoryName).HasColumnName("category_name").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Brand).HasColumnName("brand").HasColumnType("TEXT").HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnName("price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Stock).HasColumnName("stock").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.MeasurementUnit).HasColumnName("measurement_unit").HasColumnType("TEXT").HasMaxLength(10);
            entity.Property(e => e.SupplierRut).HasColumnName("supplier_rut").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.CategoryNameNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryName)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_product_category");

            entity.HasOne(d => d.SupplierRutNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierRut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_supplier");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("purchase");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.SupplierRut).HasColumnName("supplier_rut").HasColumnType("TEXT").HasMaxLength(15).IsRequired();
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id").HasColumnType("INTEGER");
            entity.Property(e => e.Total).HasColumnName("total").HasColumnType("NUMERIC");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.EmployeeIdNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_employee");

            entity.HasOne(d => d.SupplierRutNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SupplierRut)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_supplier");
        });

        modelBuilder.Entity<PurchaseProduct>(entity =>
        {
            entity.ToTable("purchase_product");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.ProductCode).HasColumnName("product_code").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.PurchaseProducts)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_product_product");

            entity.HasOne(d => d.PurchaseIdNavigation).WithMany(p => p.PurchaseProducts)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_purchase_product_purchase");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sale");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.ClientRut).HasColumnName("client_rut").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id").HasColumnType("INTEGER");
            entity.Property(e => e.Total).HasColumnName("total").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.ClientRutNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientRut)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_client");

            entity.HasOne(d => d.EmployeeIdNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_employee");
        });

        modelBuilder.Entity<SaleProduct>(entity =>
        {
            entity.ToTable("sale_product");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.SaleId).HasColumnName("sale_id").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.ProductCode).HasColumnName("product_code").HasColumnType("TEXT").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("INTEGER").IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasColumnType("NUMERIC").IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.SaleProducts)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_product_product");

            entity.HasOne(d => d.SaleIdNavigation).WithMany(p => p.SaleProducts)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_sale_product_sale");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("supplier");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Rut);
            entity.Property(e => e.Rut).HasColumnName("rut").HasColumnType("TEXT").HasMaxLength(15).IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Phone).HasColumnName("phone").HasColumnType("TEXT").HasMaxLength(15);
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100);
            entity.Property(e => e.Address).HasColumnName("address").HasColumnType("TEXT").HasMaxLength(255);
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.HasQueryFilter(e => !e.IsDeleted ?? false);
            entity.HasKey(e => e.Rut);
            entity.Property(e => e.Rut).HasColumnName("rut").HasColumnType("TEXT").HasMaxLength(15).IsRequired();
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Password).HasColumnName("password").HasColumnType("TEXT").HasMaxLength(255).IsRequired();
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("TEXT").HasMaxLength(100).IsRequired();
            entity.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("INTEGER");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.CreatedAt).HasColumnName("create_at").HasColumnType("TEXT").HasDefaultValueSql("DATETIME('now')");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasColumnType("INTEGER").HasDefaultValueSql("0");
        });
    }
}