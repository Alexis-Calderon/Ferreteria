namespace Ferreteria.Domain.Entities;

public class InventoryMovement
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = null!;
    public string MovementType { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string? Reference { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}