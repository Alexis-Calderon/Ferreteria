using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Supplier
{
    public int IdSupplier { get; set; }
    public string Name { get; set; } = null!;
    public string? Contact { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<Inventory> Inventories { get; set; } = [];
    public virtual ICollection<Purchase> Purchases { get; set; } = [];
}