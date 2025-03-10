namespace Ferreteria.Domain.Entities;

public class Supplier
{
    public string Rut { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Contact { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<Inventory> Inventories { get; set; } = [];
    public virtual ICollection<Purchase> Purchases { get; set; } = [];
}