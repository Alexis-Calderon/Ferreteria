namespace Ferreteria.Domain.Entities;

public class Inventory
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = null!;
    public int CurrentStock { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Product? ProductCodeNavigation { get; set; }
}