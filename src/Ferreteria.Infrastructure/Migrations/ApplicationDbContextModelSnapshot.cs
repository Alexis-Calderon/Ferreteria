﻿// <auto-generated />
using System;
using Ferreteria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ferreteria.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Ferreteria.Core.Entities.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdCategory");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_client");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdClient");

                    b.ToTable("client", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_employee");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<DateTime?>("HiringDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("hiring_date");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_user");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("JobPosition")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("job_position");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdEmployee");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Inventory", b =>
                {
                    b.Property<int>("IdInventory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_inventory");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int>("CurrentStock")
                        .HasColumnType("INTEGER")
                        .HasColumnName("current_stock");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_product");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<int?>("SupplierIdSupplier")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdInventory");

                    b.HasIndex("IdProduct");

                    b.HasIndex("SupplierIdSupplier");

                    b.ToTable("inventory", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.InventoryMovement", b =>
                {
                    b.Property<int>("IdInventoryMovement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_inventory_movement");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_product");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("MovementDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("movement_date");

                    b.Property<string>("MovementType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("movement_type");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("quantity");

                    b.Property<string>("Reference")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("reference");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdInventoryMovement");

                    b.HasIndex("IdProduct");

                    b.ToTable("inventory_movement", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_product");

                    b.Property<string>("Brand")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("brand");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int?>("IdCategory")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_category");

                    b.Property<int?>("IdSupplier")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_supplier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("MeasurementUnit")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("measurement_unit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("price");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER")
                        .HasColumnName("stock");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdSupplier");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Purchase", b =>
                {
                    b.Property<int>("IdPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_purchase");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("IdEmployee")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_employee");

                    b.Property<int?>("IdSupplier")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_supplier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<int?>("Total")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("total");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdPurchase");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdSupplier");

                    b.ToTable("purchase", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.PurchaseProduct", b =>
                {
                    b.Property<int>("IdPurchaseProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_purchase_product");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_product");

                    b.Property<int>("IdPurchase")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_purchase");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("unit_price");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdPurchaseProduct");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdPurchase");

                    b.ToTable("purchase_product", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_sale");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("IdClient")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_client");

                    b.Property<int?>("IdEmployee")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_employee");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("total");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdSale");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdEmployee");

                    b.ToTable("sale", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.SaleProduct", b =>
                {
                    b.Property<int>("IdSaleProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_sale_product");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_product");

                    b.Property<int>("IdSale")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_sale");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("unit_price");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdSaleProduct");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSale");

                    b.ToTable("sale_product", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Supplier", b =>
                {
                    b.Property<int>("IdSupplier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_supplier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<string>("Contact")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdSupplier");

                    b.ToTable("supplier", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_user");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("DATETIME('now')");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("update_by");

                    b.HasKey("IdUser");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Employee", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.User", "IdUserNavigation")
                        .WithOne("IdEmployeeNavigation")
                        .HasForeignKey("Ferreteria.Core.Entities.Employee", "IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_employee_user");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Inventory", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Product", "IdProductNavigation")
                        .WithMany("Inventories")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_inventory_product");

                    b.HasOne("Ferreteria.Core.Entities.Supplier", null)
                        .WithMany("Inventories")
                        .HasForeignKey("SupplierIdSupplier");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.InventoryMovement", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Product", "IdProductNavigation")
                        .WithMany("InventoryMovements")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_inventory_movement_product");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Product", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Category", "IdCategoryNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_product_category");

                    b.HasOne("Ferreteria.Core.Entities.Supplier", "IdSupplierNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdSupplier")
                        .HasConstraintName("FK_product_supplier");

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdSupplierNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Purchase", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Employee", "IdEmployeeNavigation")
                        .WithMany("Purchases")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_purchase_employee");

                    b.HasOne("Ferreteria.Core.Entities.Supplier", "IdSupplierNavigation")
                        .WithMany("Purchases")
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_purchase_supplier");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdSupplierNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.PurchaseProduct", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Product", "IdProductNavigation")
                        .WithMany("PurchaseProducts")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_purchase_product_product");

                    b.HasOne("Ferreteria.Core.Entities.Purchase", "IdPurchaseNavigation")
                        .WithMany("PurchaseProducts")
                        .HasForeignKey("IdPurchase")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_purchase_product_purchase");

                    b.Navigation("IdProductNavigation");

                    b.Navigation("IdPurchaseNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Sale", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Client", "IdClientNavigation")
                        .WithMany("Sales")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_sale_client");

                    b.HasOne("Ferreteria.Core.Entities.Employee", "IdEmployeeNavigation")
                        .WithMany("Sales")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_sale_employee");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdEmployeeNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.SaleProduct", b =>
                {
                    b.HasOne("Ferreteria.Core.Entities.Product", "IdProductNavigation")
                        .WithMany("SaleProducts")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_sale_product_product");

                    b.HasOne("Ferreteria.Core.Entities.Sale", "IdSaleNavigation")
                        .WithMany("SaleProducts")
                        .HasForeignKey("IdSale")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_sale_product_sale");

                    b.Navigation("IdProductNavigation");

                    b.Navigation("IdSaleNavigation");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Client", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Employee", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("InventoryMovements");

                    b.Navigation("PurchaseProducts");

                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Purchase", b =>
                {
                    b.Navigation("PurchaseProducts");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.Supplier", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Products");

                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Ferreteria.Core.Entities.User", b =>
                {
                    b.Navigation("IdEmployeeNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
