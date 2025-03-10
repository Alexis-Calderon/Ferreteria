namespace Ferreteria.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string UserRut { get; set; } = null!;
    public string? JobPosition { get; set; }
    public string? Phone { get; set; }
    public DateTime? HiringDate { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual User UserRutNavigation { get; set; } = null!;
    public virtual ICollection<Purchase> Purchases { get; set; } = [];
    public virtual ICollection<Sale> Sales { get; set; } = [];
}