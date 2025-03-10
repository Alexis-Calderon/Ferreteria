namespace Ferreteria.Domain.Entities;

public class Purchase
{
    public int Id { get; set; }
    public string? SupplierRut { get; set; }
    public int? EmployeeId { get; set; }
    public int? Total { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Employee? EmployeeIdNavigation { get; set; }
    public virtual Supplier? SupplierRutNavigation { get; set; }
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
}