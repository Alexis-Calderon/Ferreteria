using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Product
{
    public int IdProduct { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? IdCategory { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? MeasurementUnit { get; set; }
    public int? IdSupplier { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Supplier? IdSupplierNavigation { get; set; }
    public virtual Category? IdCategoryNavigation { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; } = [];
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    public virtual ICollection<SaleProduct> SaleProducts { get; set; } = [];
}