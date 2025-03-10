namespace Ferreteria.Domain.Entities;

public class Category
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}