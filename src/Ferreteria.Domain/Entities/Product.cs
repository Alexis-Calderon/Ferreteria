namespace Ferreteria.Domain.Entities;

public class Product
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? MeasurementUnit { get; set; }
    public string? SupplierRut { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Supplier? SupplierRutNavigation { get; set; }
    public virtual Category? CategoryNameNavigation { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; } = [];
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    public virtual ICollection<SaleProduct> SaleProducts { get; set; } = [];
}