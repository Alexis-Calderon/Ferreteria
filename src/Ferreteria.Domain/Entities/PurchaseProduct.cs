namespace Ferreteria.Domain.Entities;

public class PurchaseProduct
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public string ProductCode { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Product? ProductCodeNavigation { get; set; }
    public virtual Purchase? PurchaseIdNavigation { get; set; }
}