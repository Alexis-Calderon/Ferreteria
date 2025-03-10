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
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "NUMERIC", nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.rut);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contact = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.rut);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.rut);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    category_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    brand = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    stock = table.Column<int>(type: "INTEGER", nullable: false),
                    measurement_unit = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    supplier_rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.code);
                    table.ForeignKey(
                        name: "FK_product_category",
                        column: x => x.category_name,
                        principalTable: "category",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "FK_product_supplier",
                        column: x => x.supplier_rut,
                        principalTable: "supplier",
                        principalColumn: "rut");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    job_position = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    hiring_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_user",
                        column: x => x.user_rut,
                        principalTable: "user",
                        principalColumn: "rut");
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    current_stock = table.Column<int>(type: "INTEGER", nullable: false),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    SupplierRut = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_product",
                        column: x => x.product_code,
                        principalTable: "product",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_inventory_supplier_SupplierRut",
                        column: x => x.SupplierRut,
                        principalTable: "supplier",
                        principalColumn: "rut");
                });

            migrationBuilder.CreateTable(
                name: "inventory_movement",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    movement_type = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    movement_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    reference = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_movement", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_movement_product",
                        column: x => x.product_code,
                        principalTable: "product",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    supplier_rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: true),
                    total = table.Column<int>(type: "NUMERIC", nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchase_employee",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_purchase_supplier",
                        column: x => x.supplier_rut,
                        principalTable: "supplier",
                        principalColumn: "rut");
                });

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    client_rut = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: true),
                    total = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_client",
                        column: x => x.client_rut,
                        principalTable: "client",
                        principalColumn: "rut");
                    table.ForeignKey(
                        name: "FK_sale_employee",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchase_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    purchase_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    unit_price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchase_product_product",
                        column: x => x.product_code,
                        principalTable: "product",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_purchase_product_purchase",
                        column: x => x.purchase_id,
                        principalTable: "purchase",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sale_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sale_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    unit_price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    update_by = table.Column<string>(type: "INTEGER", nullable: true),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "DATETIME('now')"),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_product_product",
                        column: x => x.product_code,
                        principalTable: "product",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_sale_product_sale",
                        column: x => x.sale_id,
                        principalTable: "sale",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_user_rut",
                table: "employee",
                column: "user_rut",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_product_code",
                table: "inventory",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_SupplierRut",
                table: "inventory",
                column: "SupplierRut");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movement_product_code",
                table: "inventory_movement",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_name",
                table: "product",
                column: "category_name");

            migrationBuilder.CreateIndex(
                name: "IX_product_supplier_rut",
                table: "product",
                column: "supplier_rut");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_employee_id",
                table: "purchase",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_supplier_rut",
                table: "purchase",
                column: "supplier_rut");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_product_product_code",
                table: "purchase_product",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_product_purchase_id",
                table: "purchase_product",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_client_rut",
                table: "sale",
                column: "client_rut");

            migrationBuilder.CreateIndex(
                name: "IX_sale_employee_id",
                table: "sale",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_product_product_code",
                table: "sale_product",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "IX_sale_product_sale_id",
                table: "sale_product",
                column: "sale_id");
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