using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferreteria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "NUMERIC", nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id_supplier = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contact = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id_supplier);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    id_category = table.Column<int>(type: "INTEGER", nullable: true),
                    brand = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    stock = table.Column<int>(type: "INTEGER", nullable: false),
                    measurement_unit = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    id_supplier = table.Column<int>(type: "INTEGER", nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id_product);
                    table.ForeignKey(
                        name: "FK_product_category",
                        column: x => x.id_category,
                        principalTable: "category",
                        principalColumn: "id_category");
                    table.ForeignKey(
                        name: "FK_product_supplier",
                        column: x => x.id_supplier,
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id_employee = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_user = table.Column<int>(type: "INTEGER", nullable: false),
                    job_position = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    hiring_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id_employee);
                    table.ForeignKey(
                        name: "FK_employee_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id_inventory = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_product = table.Column<int>(type: "INTEGER", nullable: false),
                    current_stock = table.Column<int>(type: "INTEGER", nullable: false),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0"),
                    SupplierIdSupplier = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id_inventory);
                    table.ForeignKey(
                        name: "FK_inventory_product",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "FK_inventory_supplier_SupplierIdSupplier",
                        column: x => x.SupplierIdSupplier,
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "inventory_movement",
                columns: table => new
                {
                    id_inventory_movement = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_product = table.Column<int>(type: "INTEGER", nullable: false),
                    movement_type = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    movement_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    reference = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_movement", x => x.id_inventory_movement);
                    table.ForeignKey(
                        name: "FK_inventory_movement_product",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    id_purchase = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_supplier = table.Column<int>(type: "INTEGER", nullable: true),
                    id_employee = table.Column<int>(type: "INTEGER", nullable: true),
                    total = table.Column<int>(type: "NUMERIC", nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.id_purchase);
                    table.ForeignKey(
                        name: "FK_purchase_employee",
                        column: x => x.id_employee,
                        principalTable: "employee",
                        principalColumn: "id_employee");
                    table.ForeignKey(
                        name: "FK_purchase_supplier",
                        column: x => x.id_supplier,
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id_sale = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_client = table.Column<int>(type: "INTEGER", nullable: true),
                    id_employee = table.Column<int>(type: "INTEGER", nullable: true),
                    total = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id_sale);
                    table.ForeignKey(
                        name: "FK_sale_client",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "FK_sale_employee",
                        column: x => x.id_employee,
                        principalTable: "employee",
                        principalColumn: "id_employee");
                });

            migrationBuilder.CreateTable(
                name: "purchase_product",
                columns: table => new
                {
                    id_purchase_product = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_purchase = table.Column<int>(type: "INTEGER", nullable: false),
                    id_product = table.Column<int>(type: "INTEGER", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    unit_price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_product", x => x.id_purchase_product);
                    table.ForeignKey(
                        name: "FK_purchase_product_product",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "FK_purchase_product_purchase",
                        column: x => x.id_purchase,
                        principalTable: "purchase",
                        principalColumn: "id_purchase");
                });

            migrationBuilder.CreateTable(
                name: "sale_product",
                columns: table => new
                {
                    id_sale_product = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_sale = table.Column<int>(type: "INTEGER", nullable: false),
                    id_product = table.Column<int>(type: "INTEGER", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    unit_price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    update_by = table.Column<int>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_product", x => x.id_sale_product);
                    table.ForeignKey(
                        name: "FK_sale_product_product",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "FK_sale_product_sale",
                        column: x => x.id_sale,
                        principalTable: "sale",
                        principalColumn: "id_sale");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_id_user",
                table: "employee",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_id_product",
                table: "inventory",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_SupplierIdSupplier",
                table: "inventory",
                column: "SupplierIdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movement_id_product",
                table: "inventory_movement",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_category",
                table: "product",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_supplier",
                table: "product",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_id_employee",
                table: "purchase",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_id_supplier",
                table: "purchase",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_product_id_product",
                table: "purchase_product",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_product_id_purchase",
                table: "purchase_product",
                column: "id_purchase");

            migrationBuilder.CreateIndex(
                name: "IX_sale_id_client",
                table: "sale",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_sale_id_employee",
                table: "sale",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "IX_sale_product_id_product",
                table: "sale_product",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_sale_product_id_sale",
                table: "sale_product",
                column: "id_sale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "inventory_movement");

            migrationBuilder.DropTable(
                name: "purchase_product");

            migrationBuilder.DropTable(
                name: "sale_product");

            migrationBuilder.DropTable(
                name: "purchase");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
